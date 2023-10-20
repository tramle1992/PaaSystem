using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Model.ClientInfo
{
    public class CustomerNumberLetterId : Common.Domain.Model.Identity
    {
        public CustomerNumberLetterId(string letter) :
            base(letter)
        {

        }
        
    }
}
