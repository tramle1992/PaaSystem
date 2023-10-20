using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.DialogMessage
{
    public static class DialogMessageType
    {
        public static int Confirmation = 1;

        public static class ConfirmationType
        {
            public const int Delete = 2;
        }

        public static int InfoSuccess = 10;

        public static class InfoSuccessType
        {
            public const int Created = 11;
            public const int Updated = 12;
            public const int Deleted = 13;
        }

        public static int WarningConfirmation = 20;

        public static class WarningConfirmationType
        {
            public const int EditDocument = 21;
        }

        public static int Error = 30;
    }
}
