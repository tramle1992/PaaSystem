using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaaApi.Models
{
    public class Error
    {
        public string ErrorType { get; set; }

        public string ErrorMessage { get; set; }

        public Error(string errorType, string errorMessage)
        {
            this.ErrorType = errorType;
            this.ErrorMessage = errorMessage;
        }
    }
}