using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentityAccess.Domain.Model.Identity
{
    public class Enablement
    {

        public static Enablement IndefiniteEnablement()
        {
            return new Enablement(true, DateTime.MinValue, DateTime.MinValue);
        }

        public Enablement(bool enabled, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new InvalidOperationException("Enablement start and/or end date is invalid");
            }
            this.Enabled = enabled;
            this.EndDate = endDate;
            this.StartDate = startDate;
        }

        public bool Enabled { get; private set; }

        public DateTime EndDate { get; private set; }

        public DateTime StartDate { get; private set; }

        public bool IsEnabledmentEnablaed()
        {
            bool enabled = false;
            if (!IsTimeExpired())
            {
                enabled = true;
            }
            return enabled;
        }

        public bool IsTimeExpired()
        {
            bool timeExpired = false;
            if (this.EndDate != DateTime.MinValue && this.StartDate != DateTime.MinValue)
            {
                DateTime now = DateTime.Now;
                if (now < this.StartDate || now > this.EndDate)
                {
                    timeExpired = true;
                }
            }
            return timeExpired;
        }

        public override int GetHashCode()
        {
            int hashCodeValue = (18543 * 245)
                + (this.Enabled ? 1 : 0)
                + (this.StartDate == null ? 0 : this.StartDate.GetHashCode())
                + (this.EndDate == null ? 0 : this.EndDate.GetHashCode());
            return hashCodeValue;
        }

        public override bool Equals(object anotherObject)
        {
            bool equalObjects = false;

            if (anotherObject != null && this.GetType() == anotherObject.GetType())
            {
                Enablement typedObject = (Enablement)anotherObject;
                equalObjects =
                    this.Enabled == typedObject.Enabled &&
                    this.StartDate == typedObject.StartDate &&
                    this.EndDate == typedObject.EndDate;                
            }
            return equalObjects;
        }

        public override string ToString()
        {
            return "Enablement [enabled=" + Enabled
                + ", startDate=" + StartDate
                + ", endDate=" + EndDate + "]";
        }
    }
}
