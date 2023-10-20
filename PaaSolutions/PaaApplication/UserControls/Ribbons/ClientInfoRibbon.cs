using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaaApplication.Forms;
using IdentityAccess.Domain.Model.Identity;
using IdentityAccess.Infrastructure.Authorization;
using IdentityAccess.Domain.Model.Access;
using PaaApplication.Models.Common;

namespace PaaApplication.UserControls.Ribbons
{
    public partial class ClientInfoRibbon : UserControl
    {
        public EventHandler<EventArgs> CreateClientClick;
        public EventHandler<EventArgs> DeleteClientClick;
        public EventHandler<EventArgs> SearchClientClick;
        public EventHandler<EventArgs> ForClientClick;
        public EventHandler<EventArgs> ForShownClientClick;
        public EventHandler<EventArgs> NotForClientClick;
        public EventHandler<EventArgs> CommonPrintClick;
        public EventHandler<EventArgs> LabelClick;
        public EventHandler<EventArgs> DatagridSelectedClientsClick;
        public EventHandler<EventArgs> DatagridAllShownClientsClick;
        public EventHandler<EventArgs> EmailSelectedClientsClick;
        public EventHandler<EventArgs> EmailAllShownClientsClick;
        public EventHandler<EventArgs> EditClientPriceClick;
        public EventHandler<EventArgs> SaveClientClick;
        public EventHandler<EventArgs> RefreshClientClick;

        FormMaster formMaster;

        public ClientInfoRibbon(FormMaster master)
        {
            InitializeComponent();
            this.formMaster = master;
            CheckPermissionForRibbon();
        }

        public WordDocumentType GetDocType(RibbonButton rbtn)
        {
            if (rbtn == rbtnCommonPrintClientInfo)
            {
                return WordDocumentType.ClientInfo;
            }
            else if (rbtn == rbtnCommonPrintResContract)
            {
                return WordDocumentType.ResidentialContract;
            }
            else if (rbtn == rbtnCommonPrintEmpContract)
            {
                return WordDocumentType.EmploymentContract;
            }
            return WordDocumentType.ClientInfo;
        }

        #region Click Events
        private void rbtnCreateClient_Click(object sender, EventArgs e)
        {
            if (CreateClientClick != null)
            {
                CreateClientClick(sender, e);
            }
        }

        private void rbtnDeleteClient_Click(object sender, EventArgs e)
        {
            if (DeleteClientClick != null)
            {
                DeleteClientClick(sender, e);
            }
        }

        private void rbtnSearchClient_Click(object sender, EventArgs e)
        {
            if (SearchClientClick != null)
            {
                SearchClientClick(sender, e);
            }
        }

        private void rbtnForClient_Click(object sender, EventArgs e)
        {
            if (ForClientClick != null)
            {
                ForClientClick(sender, e);
            }
        }

        private void rbtnForShownClient_Click(object sender, EventArgs e)
        {
            if (ForShownClientClick != null)
            {
                ForShownClientClick(sender, e);
            }
        }

        private void rbtnNotForClient_Click(object sender, EventArgs e)
        {
            if (NotForClientClick != null)
            {
                NotForClientClick(sender, e);
            }
        }

        private void rbtnCommonPrint_Click(object sender, EventArgs e)
        {
            if (CommonPrintClick != null)
            {
                CommonPrintClick(sender, e);
            }
        }

        private void rbtnLabel_Click(object sender, EventArgs e)
        {
            if (LabelClick != null)
            {
                LabelClick(sender, e);
            }
        }

        private void rbtnDatagridSelectedClients_Click(object sender, EventArgs e)
        {
            if (DatagridSelectedClientsClick != null)
            {
                DatagridSelectedClientsClick(sender, e);
            }
        }

        private void rbtnDatagridAllShownClients_Click(object sender, EventArgs e)
        {
            if (DatagridAllShownClientsClick != null)
            {
                DatagridAllShownClientsClick(sender, e);
            }
        }

        private void rbtnEmailSelectedClients_Click(object sender, EventArgs e)
        {
            if (EmailSelectedClientsClick != null)
            {
                EmailSelectedClientsClick(sender, e);
            }
        }

        private void rbtnEmailAllShownClients_Click(object sender, EventArgs e)
        {
            if (EmailAllShownClientsClick != null)
            {
                EmailAllShownClientsClick(sender, e);
            }
        }

        private void rbtnEditClientPrice_Click(object sender, EventArgs e)
        {
            if (EditClientPriceClick != null)
            {
                EditClientPriceClick(sender, e);
            }
        }

        private void rbtnSaveClient_Click(object sender, EventArgs e)
        {
            if (SaveClientClick != null)
            {
                SaveClientClick(sender, e);
            }
        }

        private void rbtnRefreshClient_Click(object sender, EventArgs e)
        {
            if (RefreshClientClick != null)
            {
                RefreshClientClick(sender, e);
            }
        }

        #endregion

        private void CheckPermissionForRibbon()
        {
            User currentUser = formMaster.CURRENT_USER;
            FeatureAuthorization featureAuth = new FeatureAuthorization();

            Role role = formMaster.CURRENT_ROLE;

            if (role != null)
            {
                foreach (FeaturePermission item in role.FeaturePermissions)
                {
                    #region Client info

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.ViewClientInfo))
                    {
                        if (!item.IsAllowed)
                        {
                            rtabClientInfo.Visible = false;
                        }
                        else
                        {
                            rtabClientInfo.Visible = true;
                        }
                    }

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.AddNewClient))
                    {
                        if (!item.IsAllowed)
                        {
                            rbtnCreateClient.Visible = false;
                        }
                        else
                        {
                            rbtnCreateClient.Visible = true;
                        }
                    }

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.DeleteClient))
                    {
                        if (!item.IsAllowed)
                        {
                            rbtnDeleteClient.Visible = false;
                        }
                        else
                        {
                            rbtnDeleteClient.Visible = true;
                        }
                    }

                    if (!rbtnDeleteClient.Visible && !rbtnCreateClient.Visible)
                    {
                        rpnlCreateClient.Visible = false;
                    }

                    if (item.FeatureName == featureAuth.FeatureNameToString(FeatureName.EditSpecialPrice))
                    {
                        if (!item.IsAllowed)
                        {
                            rbtnEditClientPrice.Visible = false;
                            rpnlEditPrice.Visible = false;
                        }
                        else
                        {
                            rbtnEditClientPrice.Visible = true;
                            rpnlEditPrice.Visible = true;
                        }
                    }

                    #endregion
                }
            }
        }
    }
}
