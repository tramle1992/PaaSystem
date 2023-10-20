using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    // Entity: An object fundamentally defined not by its attributes, but by a thread of continuity and identity.
    public abstract class Entity { }

    public abstract class EntityWithCompositeId : Entity
    {
        /// <summary>
        /// When overriden in a derived class, gets all components of the identity of the entity.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetIdentityComponents();

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            if (object.ReferenceEquals(null, obj)) return false;
            if (GetType() != obj.GetType()) return false;
            var other = obj as EntityWithCompositeId;
            return GetIdentityComponents().SequenceEqual(other.GetIdentityComponents());
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(GetIdentityComponents());
        }
    }
}
