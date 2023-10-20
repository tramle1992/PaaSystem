using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    public class CustomerNumberSetting 
    {
        public char Letter { get; set; }
        public int LastNumber { get; set; }            

        public CustomerNumberSetting(char letter, int lastNumber)
        {
            this.Letter = letter;
            this.LastNumber = lastNumber;
        }

        public CustomerNumberSetting()
        {            
        }   
    }
}
