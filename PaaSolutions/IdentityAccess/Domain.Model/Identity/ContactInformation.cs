using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Domain.Model;

namespace IdentityAccess.Domain.Model.Identity
{
    public class ContactInformation : ValueObject
    {

        public ContactInformation(
            string emailAddress,
            string postalAddress,
            string primaryTelephone,
            string secondaryTelephone)
        {
            this.EmailAddress = emailAddress;
            this.PostalAddress = postalAddress;
            this.PrimaryTelephone = primaryTelephone;
            this.SecondaryTelephone = secondaryTelephone;
        }

        public ContactInformation(ContactInformation contactInformation)
            : this(contactInformation.EmailAddress,
                    contactInformation.PostalAddress,
                    contactInformation.PrimaryTelephone,
                    contactInformation.SecondaryTelephone)
        {

        }

        protected ContactInformation() { }

        public string EmailAddress { get; private set; }

        public string PostalAddress { get; private set; }

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }

        public ContactInformation ChangeEmailAddress(string emailAddress)
        {
            return new ContactInformation(
                emailAddress,
                this.PostalAddress,
                this.PrimaryTelephone,
                this.SecondaryTelephone);
        }

        public ContactInformation ChangePostalAddress(string postalAddress)
        {
            return new ContactInformation(
                this.EmailAddress,
                postalAddress,
                this.PrimaryTelephone,
                this.SecondaryTelephone);
        }

        public ContactInformation ChangePrimaryTelephone(string telephone)
        {
            return new ContactInformation(
                this.EmailAddress,
                this.PostalAddress,
                telephone,
                this.SecondaryTelephone);
        }

        public ContactInformation ChangeSecondaryTelephone(string telephone)
        {
            return new ContactInformation(
                this.EmailAddress,
                this.PostalAddress,
                this.PrimaryTelephone,
                telephone);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.EmailAddress;
            yield return this.PostalAddress;
            yield return this.PrimaryTelephone;
            yield return this.SecondaryTelephone;
        }

        public override string ToString()
        {
            return "ContactInformation [emailAddress=" + EmailAddress
                + ", postalAddress=" + PostalAddress
                + ", primaryTelephone=" + PrimaryTelephone
                + ", secondaryTelephone=" + SecondaryTelephone + "]";
        }

    }
}
