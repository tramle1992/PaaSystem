using Administration.Domain.Model.InternetTool;
using Administration.Infrastructure.InternetTool;
using BrightIdeasSoftware;
using Common.Infrastructure.ApiClient;
using Common.Infrastructure.OLV;
using Common.Infrastructure.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaaApplication.Forms.Administration
{
    public partial class FormInternetTools : BaseForm
    {
        enum Mode
        {
            Edit,
            AddNew
        }

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private InternetToolApiRepository apiRepository = new InternetToolApiRepository();
        private InternetToolCachedApiQuery cachedApiQuery = InternetToolCachedApiQuery.Instance;

        private Mode mode = Mode.Edit;
        private bool isFiltering = false;
        //private List<InternetItem> data = null;

        private const int MAXIMUM_ITEM = 20;
        private const int MAXIMUM_IMAGE_SIZE = 1048576; // 1MB

        private const int MAXIMUM_IMAGE_WIDTH = 70;
        private const int MAXIMUM_IMAGE_HEIGHT = 70;

        private const string DEFAULT_TARGET = "http://www.bemroseconsulting.com/";

        FormMaster formMaster;
        public FormInternetTools(FormMaster formMaster)
        {
            InitializeComponent();
            this.formMaster = formMaster;
        }

        private void FormInternetTools_LoadCompleted(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass())
                {
                    InitOLV();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                MessageBox.Show(ex.Message);                
            }
        }

        private void LoadData()
        {
            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();
            LoadOLVInternetItems(data, null);
            SetEnableOrderButtons();
        }

        private void LoadOLVInternetItems(List<InternetItem> internetList, InternetItem selectedItem)
        {
            if (internetList == null || internetList.Count == 0)
            {
                this.olvInternetItems.ClearObjects();
                return;
            }

            this.olvInternetItems.SetObjects(internetList);
            this.olvInternetItems.BuildList();

            if (selectedItem == null || string.IsNullOrEmpty(selectedItem.InternetItemId.Id))
            {
                this.olvInternetItems.SelectedIndex = 0;
                this.olvInternetItems.EnsureVisible(0);
            }
            else
            {
                for (int i = 0; i < this.olvInternetItems.Items.Count; i++)
                {
                    InternetItem item = (InternetItem)this.olvInternetItems.GetModelObject(i);
                    if (item != null && !string.IsNullOrEmpty(item.InternetItemId.Id) &&
                        item.InternetItemId.Id.Equals(selectedItem.InternetItemId.Id))
                    {
                        this.olvInternetItems.SelectedIndex = i;
                        this.olvInternetItems.EnsureVisible(i);
                        break;
                    }
                }
            }
        }

        private void InitOLV()
        {
            this.olvcolBtnDelete.ImageGetter = delegate(object row)
            {
                return 0;
            };

            this.olvInternetItems.RowHeight = 80;

            this.olvcolImage.CellPadding = new Rectangle(40, 15, MAXIMUM_IMAGE_WIDTH, MAXIMUM_IMAGE_HEIGHT);

            this.olvcolImage.ImageGetter = delegate(object row)
            {
                if (row != null)
                {
                    try
                    {
                        byte[] imageBuffer = ((InternetItem)row).Image;
                        if (imageBuffer.Length > 0)
                        {
                            using (MemoryStream memoryStream = new MemoryStream(imageBuffer))
                            {
                                return Image.FromStream(memoryStream);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex.ToString());
                    }
                }
                return null;
            };
        }

        private void olvInternetItems_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
        }

        private void olvInternetItems_CellEditValidating(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (this.mode == Mode.AddNew)
            {
                InternetItem item = (InternetItem)e.RowObject;
                if (item == null)
                {
                    e.Cancel = true;
                    return;
                }

                string value;

                List<InternetItem> data = cachedApiQuery.GetAllInternetItems();
                if (e.Column == this.olvcolCaption)
                {
                    value = e.NewValue.ToString().Trim();
                    if (string.IsNullOrEmpty(value))
                    {
                        MessageBox.Show("Caption cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (value.Length > 100)
                    {
                        MessageBox.Show("Caption cannot be longer than 100 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (GetInternetItemIndexByCaption(data, value) >= 0)
                    {
                        MessageBox.Show("Caption already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        item.Caption = value;
                    }
                }

                using (new HourGlass())
                {
                    if (HasMaximumItem())
                    {
                        return;
                    }

                    int maxOrder = apiRepository.FindMaxOrder();
                    if (maxOrder >= int.Parse(byte.MaxValue.ToString()) || maxOrder != this.olvInternetItems.Items.Count)
                    {
                        ReorderAllInternetItems();
                        data = cachedApiQuery.GetAllInternetItems();
                        maxOrder = data.Count + 1;
                    }
                    else
                    {
                        maxOrder += 1;
                    }
                    item.Order = (byte)maxOrder;
                    string internetItemId = apiRepository.Add(item);
                    if (!string.IsNullOrEmpty(internetItemId))
                    {
                        item.InternetItemId = new InternetItemId(internetItemId);
                        AddInternetItemCompleted(item);
                    }
                }
            }
            else if (this.mode == Mode.Edit)
            {
                InternetItem item = (InternetItem)e.RowObject;
                if (item == null)
                {
                    e.Cancel = true;
                    return;
                }

                string oldValue;
                string newValue;
                bool update = false;

                List<InternetItem> data = cachedApiQuery.GetAllInternetItems();
                if (e.Column == this.olvcolCaption)
                {
                    oldValue = e.Value.ToString();
                    newValue = e.NewValue.ToString().Trim();
                    if (string.IsNullOrEmpty(newValue))
                    {
                        MessageBox.Show("Caption cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (newValue.Length > 100)
                    {
                        MessageBox.Show("Caption cannot be longer than 100 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (!oldValue.Equals(newValue))
                    {
                        if (GetInternetItemIndexByCaption(data, newValue) >= 0)
                        {
                            MessageBox.Show("Caption already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            item.Caption = newValue;
                            update = true;
                        }
                    }
                }
                else if (e.Column == this.olvcolTarget)
                {
                    oldValue = e.Value.ToString();
                    newValue = e.NewValue.ToString().Trim().ToLower();
                    if (string.IsNullOrEmpty(newValue))
                    {
                        MessageBox.Show("Target cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (newValue.Length > 2000)
                    {
                        MessageBox.Show("Target cannot be longer than 2000 characters!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (!Regex.IsMatch(newValue, @"^([(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*))$",
                                            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    {
                        MessageBox.Show("Target is invalid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else if (!oldValue.Equals(newValue))
                    {
                        item.Target = newValue;
                        update = true;
                    }
                }

                if (update)
                {
                    using (new HourGlass())
                    {
                        apiRepository.Update(item);
                        UpdateInternetItemCompleted(item);
                    }
                }
            }

            this.mode = Mode.Edit;
        }

        private void olvInternetItems_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            InternetItem item = (InternetItem)e.RowObject;
            if (item == null)
            {
                this.mode = Mode.Edit;
                return;
            }

            if (e.Cancel && this.mode == Mode.AddNew)
            {
                this.olvInternetItems.RemoveObject(item);
            }
            else if (!e.Cancel)
            {
                if (e.Column == this.olvcolCaption)
                {
                    item.Caption = e.NewValue.ToString();
                }
                else if (e.Column == this.olvcolTarget)
                {
                    item.Target = e.NewValue.ToString().Trim().ToLower();
                }

                this.olvInternetItems.RefreshObject(item);
                e.Cancel = true;
            }

            this.mode = Mode.Edit;
        }

        private void olvInternetItems_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            InternetItem item = (InternetItem)this.olvInternetItems.SelectedObject;
            if (item == null)
            {
                return;
            }

            if (e.Column == this.olvcolBtnDelete)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete \"" + item.Caption + "\" item?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    using (new HourGlass())
                    {
                        apiRepository.Remove(item);
                        RemoveInternetItemCompleted(item);
                    }
                }
            }
            else if (e.Column == this.olvcolImage)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = GetImageFilter();
                dialog.Title = "Select an image file";
                dialog.FileOk += delegate(object delegateSender, CancelEventArgs delegateArgs)
                {
                    long fileSize = new FileInfo(dialog.FileName).Length;
                    if (fileSize > MAXIMUM_IMAGE_SIZE)
                    {
                        MessageBox.Show("Sorry, file has exceeded 1MB!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        delegateArgs.Cancel = true;
                    }
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (new HourGlass())
                    {
                        Image originalImage = Image.FromFile(dialog.FileName);
                        Image resizedImage = ResizeImage(originalImage,
                            new Size(MAXIMUM_IMAGE_WIDTH, MAXIMUM_IMAGE_HEIGHT), true);
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            resizedImage.Save(memoryStream, ImageFormat.Png);
                            byte[] imageData = memoryStream.ToArray();
                            if (imageData.Length > 0)
                            {
                                item.Image = imageData;
                                apiRepository.Update(item);
                                UpdateInternetItemCompleted(item);
                            }
                        }
                    }
                }
            }
        }

        private void olvInternetItems_SelectionChanged(object sender, EventArgs e)
        {
            SetEnableOrderButtons();
        }

        private void SetEnableOrderButtons()
        {
            if (isFiltering)
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                return;
            }

            int itemCount = this.olvInternetItems.Items.Count;
            int selectedIndex = this.olvInternetItems.SelectedIndex;
            if (itemCount <= 1 || selectedIndex < 0)
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
            else
            {
                if (selectedIndex == 0)
                {
                    btnUp.Enabled = false;
                    btnDown.Enabled = true;
                }
                else if (selectedIndex == itemCount - 1)
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = false;
                }
                else
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                }
            }
        }

        public string GetImageFilter()
        {
            StringBuilder allImageExtensions = new StringBuilder();
            string separator = "";
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            Dictionary<string, string> images = new Dictionary<string, string>();
            foreach (ImageCodecInfo codec in codecs)
            {
                allImageExtensions.Append(separator);
                allImageExtensions.Append(codec.FilenameExtension);
                separator = ";";
                images.Add(string.Format("{0} Files: ({1})", codec.FormatDescription, codec.FilenameExtension),
                           codec.FilenameExtension);
            }
            StringBuilder sb = new StringBuilder();
            if (allImageExtensions.Length > 0)
            {
                sb.AppendFormat("{0}|{1}", "All Images", allImageExtensions.ToString());
            }
            foreach (KeyValuePair<string, string> image in images)
            {
                sb.AppendFormat("|{0}|{1}", image.Key, image.Value);
            }
            return sb.ToString();
        }

        private int GetInternetItemIndexById(List<InternetItem> internetList, string internetItemId)
        {
            if (internetList == null || internetList.Count == 0 || string.IsNullOrEmpty(internetItemId))
            {
                return -1;
            }

            return internetList.FindIndex(
                delegate(InternetItem internetItem)
                {
                    return internetItem.InternetItemId.Id.Equals(internetItemId);
                });
        }

        private int GetInternetItemIndexByCaption(List<InternetItem> internetList, string caption)
        {
            if (internetList == null || internetList.Count == 0 || string.IsNullOrEmpty(caption))
            {
                return -1;
            }

            return internetList.FindIndex(
                delegate(InternetItem internetItem)
                {
                    return internetItem.Caption.Equals(caption);
                });
        }

        private void AddInternetItemCompleted(InternetItem item)
        {
            if (item == null)
            {
                return;
            }

            // remove cache & get new
            cachedApiQuery.RemoveAllInternetItems();
            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();

            // reload OLVInternetItems
            LoadOLVInternetItems(data, item);
        }

        private void UpdateInternetItemCompleted(InternetItem item)
        {
            if (item == null)
            {
                return;
            }

            // remove cache & get new
            cachedApiQuery.RemoveAllInternetItems();
            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();

            // reload OLVInternetItems
            LoadOLVInternetItems(data, item);
        }

        private void RemoveInternetItemCompleted(InternetItem item)
        {
            if (item == null)
            {
                return;
            }

            // remove cache & get new
            cachedApiQuery.RemoveAllInternetItems();
            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();

            // reload OLVInternetItems
            LoadOLVInternetItems(data, null);
        }

        private void ReorderAllInternetItems()
        {
            // remove cache & get new
            cachedApiQuery.RemoveAllInternetItems();
            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();

            if (data == null || data.Count == 0)
            {
                return;
            }

            // reorder
            for (int i = 0; i < data.Count; i++)
            {
                data[i].Order = (byte)(i + 1);
            }

            // update to database
            apiRepository.MultiUpdate(data);

            // remove cache & get new
            cachedApiQuery.RemoveAllInternetItems();
            data = cachedApiQuery.GetAllInternetItems();

            // reload OLVInternetItems
            LoadOLVInternetItems(data, null);
        }

        private Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            if (image.Width < size.Width && image.Height < size.Height)
            {
                return image;
            }

            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            Image newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        private void SwapInternetItemFromList(List<InternetItem> internetList, int indexA, int indexB)
        {
            if (internetList == null || internetList.Count == 0 ||
                indexA < 0 || indexA == internetList.Count ||
                indexB < 0 || indexB == internetList.Count ||
                indexA == indexB)
            {
                return;
            }

            InternetItem tmp = internetList[indexA];
            internetList[indexA] = internetList[indexB];
            internetList[indexB] = tmp;
        }

        private bool HasMaximumItem()
        {
            int itemCountInDB = apiRepository.GetItemCount();

            if (itemCountInDB != this.olvInternetItems.Items.Count)
            {
                cachedApiQuery.RemoveAllInternetItems();
                LoadData();
            }

            if (itemCountInDB >= MAXIMUM_ITEM)
            {
                MessageBox.Show("Internet Tools item has exceeded " + MAXIMUM_ITEM + " items.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private void SwapInternetItemCompleted(InternetItem selectedItem)
        {
            // remove cache & get new
            cachedApiQuery.RemoveAllInternetItems();
            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();

            if (data == null || data.Count == 0)
            {
                this.olvInternetItems.ClearObjects();
                return;
            }

            this.olvInternetItems.SetObjects(data);
            this.olvInternetItems.BuildList();

            for (int i = 0; i < this.olvInternetItems.Items.Count; i++)
            {
                InternetItem item = (InternetItem)this.olvInternetItems.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.InternetItemId.Id) &&
                    item.InternetItemId.Id.Equals(selectedItem.InternetItemId.Id))
                {
                    this.olvInternetItems.SelectedIndex = i;
                    this.olvInternetItems.EnsureVisible(i);
                    break;
                }
            }

            this.olvInternetItems.Focus();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.olvInternetItems.SelectedIndex;
            if (selectedIndex == 0)
            {
                return;
            }

            int maxOrder = apiRepository.FindMaxOrder();
            if (maxOrder >= int.Parse(byte.MaxValue.ToString()) || maxOrder != this.olvInternetItems.Items.Count)
            {
                ReorderAllInternetItems();
                MessageBox.Show("Data has been updated!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();

            InternetItem previousItem = data[selectedIndex - 1];
            InternetItem selectedItem = data[selectedIndex];

            selectedItem.Order = previousItem.Order;
            previousItem.Order += 1;

            //SwapInternetItemFromList(data, selectedIndex - 1, selectedIndex);

            using (new HourGlass())
            {
                apiRepository.Update(previousItem);
                apiRepository.Update(selectedItem);

                SwapInternetItemCompleted(selectedItem);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.olvInternetItems.SelectedIndex;
            if (selectedIndex == this.olvInternetItems.Items.Count - 1)
            {
                return;
            }

            int maxOrder = apiRepository.FindMaxOrder();
            if (maxOrder >= int.Parse(byte.MaxValue.ToString()) || maxOrder != this.olvInternetItems.Items.Count)
            {
                ReorderAllInternetItems();
                MessageBox.Show("Data has been updated!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<InternetItem> data = cachedApiQuery.GetAllInternetItems();

            InternetItem selectedItem = data[selectedIndex];
            InternetItem nextItem = data[selectedIndex + 1];

            nextItem.Order = selectedItem.Order;
            selectedItem.Order += 1;

            //SwapInternetItemFromList(data, selectedIndex, selectedIndex + 1);

            using (new HourGlass())
            {
                apiRepository.Update(selectedItem);
                apiRepository.Update(nextItem);

                SwapInternetItemCompleted(selectedItem);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (new HourGlass())
            {
                if (HasMaximumItem())
                {
                    return;
                }

                this.mode = Mode.AddNew;
                InternetItem item = new InternetItem();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Properties.Resources.gallery.Save(memoryStream, ImageFormat.Png);
                    item.Image = memoryStream.ToArray();
                }
                item.Target = DEFAULT_TARGET;
                this.olvInternetItems.AddObject(item);
                this.olvInternetItems.SelectedIndex = this.olvInternetItems.Items.Count - 1;
                this.olvInternetItems.EnsureVisible(this.olvInternetItems.Items.Count - 1);
                this.olvInternetItems.EditSubItem(this.olvInternetItems.GetItem(this.olvInternetItems.Items.Count - 1), 1);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string strSearch = txtSearch.Text.Trim();
            bool hasChange = false;

            if (e.KeyCode == Keys.Back && strSearch == string.Empty)
            {
                new ObjectListViewService().FilterOlv(this.olvInternetItems, strSearch);
                hasChange = true;
                isFiltering = false;
            }
            else if (e.KeyCode == Keys.Enter && strSearch.Length > 0)
            {
                new ObjectListViewService().FilterOlv(this.olvInternetItems, strSearch);
                hasChange = true;
                isFiltering = true;
            }

            if (hasChange)
            {
                SetEnableOrderButtons();
            }
        }

        private InternetItem GetSelectedItem()
        {
            if (this.olvInternetItems.Items.Count > 0 && this.olvInternetItems.SelectedObjects.Count > 0)
            {
                InternetItem item = (InternetItem)olvInternetItems.SelectedObjects[olvInternetItems.SelectedObjects.Count - 1];
                return item;
            }

            return null;
        }

        public void RefreshData()
        {
            try
            {
                InternetItem selectedItem = GetSelectedItem();
                this.RefreshInternetData(selectedItem);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show(ex.Message);                
            }
        }

        public void RefreshInternetData(InternetItem selectedRole)
        {
            List<InternetItem> items = formMaster.LIST_INTERNET_TOOLS;

            if (items == null || items.Count == 0)
            {
                this.olvInternetItems.ClearObjects();
                return;
            }
            this.olvInternetItems.SetObjects(items);

            if (selectedRole == null || string.IsNullOrEmpty(selectedRole.InternetItemId.Id))
            {
                this.olvInternetItems.SelectedIndex = 0;
                this.olvInternetItems.EnsureVisible(0);
                return;
            }

            for (int i = 0; i < this.olvInternetItems.Items.Count; i++)
            {
                InternetItem item = (InternetItem)this.olvInternetItems.GetModelObject(i);
                if (item != null && !string.IsNullOrEmpty(item.InternetItemId.Id) &&
                    item.InternetItemId.Id.Equals(selectedRole.InternetItemId.Id))
                {
                    this.olvInternetItems.SelectedIndex = i;
                    this.olvInternetItems.EnsureVisible(i);
                    break;
                }
            }
        }

    }
}
