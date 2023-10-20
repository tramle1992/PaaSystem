using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Application.DialogMessage
{
    public class DialogMessageFactory
    {
        public static DialogMessage BuildDialogMessage(int dialogMessageType)
        {
            DialogMessage dialogMessage = new DialogMessage();
            if (dialogMessageType > DialogMessageType.Confirmation &&
                dialogMessageType < DialogMessageType.InfoSuccess)
            {
                dialogMessage.MessageIcon = MessageBoxIcon.Question;
                dialogMessage.MessageButton = MessageBoxButtons.YesNo;
                dialogMessage.MessageDefaultButton = MessageBoxDefaultButton.Button2;
                dialogMessage.MessageCaption = "Confirmation";
                dialogMessage.MessageContent = "Are you sure you want to delete this item?";
            }
            else if (dialogMessageType > DialogMessageType.InfoSuccess &&
                dialogMessageType < DialogMessageType.WarningConfirmation)
            {
                dialogMessage.MessageIcon = MessageBoxIcon.Information;
                dialogMessage.MessageButton = MessageBoxButtons.OK;
                dialogMessage.MessageDefaultButton = MessageBoxDefaultButton.Button1;
                dialogMessage.MessageCaption = "Successfully";
                switch(dialogMessageType)
                {
                    case DialogMessageType.InfoSuccessType.Created:
                        dialogMessage.MessageContent = "You have created item successfully";
                        break;
                    case DialogMessageType.InfoSuccessType.Updated:
                        dialogMessage.MessageContent = "You have updated item successfully";
                        break;
                    case DialogMessageType.InfoSuccessType.Deleted:
                        dialogMessage.MessageContent = "You have deleted item successfully";
                        break;
                }
                
            }
            else if (dialogMessageType > DialogMessageType.WarningConfirmation &&
                dialogMessageType < DialogMessageType.Error)
            {
                dialogMessage.MessageIcon = MessageBoxIcon.Warning;
                dialogMessage.MessageButton = MessageBoxButtons.YesNo;
                dialogMessage.MessageDefaultButton = MessageBoxDefaultButton.Button2;
                dialogMessage.MessageCaption = "Warning";
                switch(dialogMessageType)
                {
                    case DialogMessageType.WarningConfirmationType.EditDocument:
                        dialogMessage.MessageContent = "Editing document may cause unexpected issue if this document is being use as template in report. " +
                            "\n Do you want to continue?";
                        break;
                }
                dialogMessage.MessageContent = "Are you sure you want to delete this item?";
            }
            else if (dialogMessageType == DialogMessageType.Error)
            {
                dialogMessage.MessageIcon = MessageBoxIcon.Error;
                dialogMessage.MessageButton = MessageBoxButtons.OK;
                dialogMessage.MessageDefaultButton = MessageBoxDefaultButton.Button1;
                dialogMessage.MessageCaption = "Error";
                dialogMessage.MessageContent = "An error has occured";
            }

            return dialogMessage;
        }
    }
}
