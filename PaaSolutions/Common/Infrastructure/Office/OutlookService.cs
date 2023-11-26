using NetOffice.OutlookApi.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Outlook = NetOffice.OutlookApi;
using Word = NetOffice.WordApi;
using MailMessage = System.Net.Mail.MailMessage;

namespace Common.Infrastructure.Office
{
    public class OutlookService
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Object oMissing = Type.Missing;
        private string subject;
        private string to;
        private string cc;
        private string filePath;
        private Outlook.Application oApplication;
        //private Outlook.ApplicationClass oApplicationClass;
        private Outlook.MailItem oMailItem;
        private Outlook.Inspector oInspector;
        private MailMessage mailMessage;

        public event EventHandler OnOutlookClose;

        public OutlookService(bool isCreatedMailItem = true)
        {
            if (isCreatedMailItem)
            {
                oApplication = new Outlook.Application();
                oMailItem = (Outlook.MailItem)oApplication.CreateItem(OlItemType.olMailItem);
                oInspector = (Outlook.Inspector)oMailItem.GetInspector;

                // Init events
                InitEventHandler();
            }
            else
            {
                mailMessage = new MailMessage();
            }
        }

        public OutlookService(string subject, string to, string cc, string body, string filePath, bool isCreatedMailItem = true)
        {
            this.subject = subject;
            this.to = to;
            this.cc = cc;
            this.filePath = filePath;

            if (isCreatedMailItem)
            {
                oApplication = new Outlook.Application();
                oMailItem = (Outlook.MailItem)oApplication.CreateItem(OlItemType.olMailItem);
                oInspector = (Outlook.Inspector)oMailItem.GetInspector;
                oMailItem.Subject = subject;
                oMailItem.To = to;
                oMailItem.CC = cc;
                oMailItem.Attachments.Add(filePath, oMissing, oMissing, oMissing);
                oMailItem.BodyFormat = OlBodyFormat.olFormatHTML;
                oMailItem.HTMLBody = body;

                // Init events
                InitEventHandler();
            }
            else 
            { 
                mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("q7891@outlook.com.vn");
                mailMessage.Subject = subject;
                mailMessage.To.Add(to);
                if (!string.IsNullOrEmpty(cc)) mailMessage.CC.Add(cc);
                var attachment = new Attachment(filePath);
                mailMessage.Attachments.Add(attachment);
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
            }
        }

        public OutlookService(string subject, string to, string cc, string body, List<string> attachments, bool isCreatedMailItem = true)
        {
            this.subject = subject;
            this.to = to;
            this.cc = cc;
            this.filePath = string.Empty;

            if (isCreatedMailItem)
            {
                oApplication = new Outlook.Application();
                oMailItem = (Outlook.MailItem)oApplication.CreateItem(OlItemType.olMailItem);
                oInspector = (Outlook.Inspector)oMailItem.GetInspector;
                oMailItem.Subject = subject;
                oMailItem.To = to;
                oMailItem.CC = cc;
                oMailItem.BodyFormat = OlBodyFormat.olFormatHTML;
                oMailItem.HTMLBody = body;
                try
                {
                    foreach (var filePath in attachments)
                    {
                        oMailItem.Attachments.Add(filePath, oMissing, oMissing, oMissing);
                    }
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    throw new WarningException("Please use PDF format instead. The attachment size exceeds the allowable limit!");
                }

                InitEventHandler();
            }
            else
            {
                mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("q7891@outlook.com.vn");
                mailMessage.Subject = subject;
                mailMessage.To.Add(to);
                if (!string.IsNullOrEmpty(cc)) mailMessage.CC.Add(cc);
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                try
                {
                    foreach (var filePath in attachments)
                    {
                        var attachment = new Attachment(filePath);
                        mailMessage.Attachments.Add(attachment);
                    }
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    throw new WarningException("Please use PDF format instead. The attachment size exceeds the allowable limit!");
                }
            }
        }

        private void InitEventHandler()
        {
            oApplication.QuitEvent += new Outlook.Application_QuitEventHandler(Application_Event_Quit);
        }

        private void Application_Event_Quit()
        {
            if (OnOutlookClose != null)
            {
                OnOutlookClose(this, null);
            }
        }

        public void SetSubject(string subject)
        {
            try
            {
                this.subject = subject;
                oMailItem.Subject = subject;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetTo(string to)
        {
            try
            {
                this.to = to;
                oMailItem.To = to;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetTo(List<string> lstTo)
        {
            try
            {
                Outlook.Recipients oRecips = oMailItem.Recipients;
                for (int i = 0; i < oRecips.Count; i++)
                {
                    Outlook.Recipient oRecip = oRecips.Cast<Outlook.Recipient>().ElementAt(i);
                    if (oRecip.Type == (int)OlMailRecipientType.olTo)
                    {
                        oMailItem.Recipients.Remove(i);
                    }
                }
                Outlook.Recipient oRecipTo = null;
                foreach (string to in lstTo)
                {
                    oRecipTo = oMailItem.Recipients.Add(to);
                    oRecipTo.Type = (int)OlMailRecipientType.olTo;
                }
                oMailItem.Recipients.ResolveAll();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }
        
        public void SetCC(string cc)
        {
            try
            {
                this.cc = cc;
                oMailItem.CC = cc;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetCC(List<string> lstCc)
        {
            try
            {
                Outlook.Recipients oRecips = oMailItem.Recipients;
                for (int i = 0; i < oRecips.Count; i++)
                {
                    Outlook.Recipient oRecip = oRecips.Cast<Outlook.Recipient>().ElementAt(i);
                    if (oRecip.Type == (int)OlMailRecipientType.olCC)
                    {
                        oMailItem.Recipients.Remove(i);
                    }
                }
                Outlook.Recipient oRecipCC = null;
                foreach (string cc in lstCc)
                {
                    oRecipCC = oMailItem.Recipients.Add(cc);
                    oRecipCC.Type = (int)OlMailRecipientType.olCC;
                }
                oMailItem.Recipients.ResolveAll();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
            
        }

        public void SetBcc(List<string> lstBcc)
        {
            try
            {
                Outlook.Recipients oRecips = oMailItem.Recipients;
                for (int i = 0; i < oRecips.Count; i++)
                {
                    Outlook.Recipient oRecip = oRecips.Cast<Outlook.Recipient>().ElementAt(i);
                    if (oRecip.Type == (int)OlMailRecipientType.olBCC)
                    {
                        oMailItem.Recipients.Remove(i);
                    }
                }
                Outlook.Recipient oRecipBCC = null;
                foreach (string bcc in lstBcc)
                {
                    oRecipBCC = oMailItem.Recipients.Add(bcc);
                    oRecipBCC.Type = (int)OlMailRecipientType.olBCC;
                }
                oMailItem.Recipients.ResolveAll();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void SetAttachment(string filePath)
        {
            try
            {
                this.filePath = filePath;
                oMailItem.Attachments.Add(filePath, oMissing, oMissing, oMissing);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void Display()
        {
            try
            {
                oMailItem.Display(false);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void Send()
        {
            try
            {
                // Config smtp
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp-mail.outlook.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("q7891@outlook.com.vn", "kpcvpdklrxebgrpu");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                // Perform send
                smtpClient.Send(mailMessage);

                //MessageBox.Show("The email has sent");
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                _logger.Error(ex.ToString());
                throw new InvalidOperationException("Could not send the email.\n Please make sure you allow the application to send the email.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw;
            }
        }

        public void Quit()
        {
            if (oApplication != null)
                oApplication.Quit();
        }

        public void SetNull()
        {
            oApplication = null;
            oMailItem = null;
            oInspector = null;
        }
    }
}
