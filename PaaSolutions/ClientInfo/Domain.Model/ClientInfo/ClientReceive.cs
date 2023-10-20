using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace Core.Domain.Model.ClientInfo
{
    /// <summary>
    /// What the client will receive
    /// </summary>
    public class ClientReceive : ValueObject
    {

        public ClientReceive(bool declinationLetter, int invoicesCopiesNumber, bool credentialed)
        {
            this.DeclinationLetter = declinationLetter;
            this.InvoicesCopiesNumber = invoicesCopiesNumber;
            this.Credentialed = credentialed;
        }

        public ClientReceive(ClientReceive clientReceive) : 
            this(clientReceive.DeclinationLetter,
            clientReceive.InvoicesCopiesNumber, clientReceive.Credentialed)
        {
        }

        public bool DeclinationLetter { get; private set; }

        public int InvoicesCopiesNumber { get; private set; }

        public bool Credentialed { get; private set; }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return DeclinationLetter;
            yield return InvoicesCopiesNumber;
            yield return Credentialed;
        }

        public override string ToString()
        {
            return "ClientReceive[declinationLetter=" + DeclinationLetter
                + ", invoicesCopiesNumber=" + InvoicesCopiesNumber
                + ", credentialed=" + Credentialed + "]";
        }
    }
}
