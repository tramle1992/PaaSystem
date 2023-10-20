using Core.Application.Data.ClientInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models.AppExplore
{
    public class ClientAppliedChangedEventArgs : EventArgs
    {
        public enum ChangedBy { BySelect, ByEnterKeyPress };

        public ClientData NewClientApplied;
        public ChangedBy ClientChangedBy;


        public ClientAppliedChangedEventArgs(ClientData newClientApplied, ChangedBy changedBy)
        {
            this.NewClientApplied = newClientApplied;
            this.ClientChangedBy = changedBy;
        }
    }
}
