﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public abstract class Identity : IEquatable<Identity>, IIdentity
    {
        public Identity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Identity(string id)
        {
            this.Id = id;
        }

        // currently for Entity Framework, set must be protected, not private.
        // will be fixed in EF 6.
        public string Id { get; set; }

        public bool Equals(Identity id)
        {
            if (object.ReferenceEquals(this, id)) return true;
            if (object.ReferenceEquals(null, id)) return false;
            return this.Id.Equals(id.Id);
        }

        public override bool Equals(object anotherObject)
        {
            return Equals(anotherObject as Identity);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
