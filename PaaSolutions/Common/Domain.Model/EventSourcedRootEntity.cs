using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public abstract class EventSourcedRootEntity : EntityWithCompositeId
    {
        public EventSourcedRootEntity()
        {
            this.mutatingEvents = new List<IDomainEvent>();
        }

        public EventSourcedRootEntity(IEnumerable<IDomainEvent> eventStream, int streamVersion) : this()
        {
            foreach (var e in eventStream)
                When(e);
            this.unmutaedVersion = streamVersion;
        }

        readonly List<IDomainEvent> mutatingEvents;
        readonly int unmutaedVersion;

        protected int MutatedVersion
        {
            get { return this.unmutaedVersion + 1; }
        }

        protected int UnmutatedVersion
        {
            get { return this.unmutaedVersion; }
        }

        public IList<IDomainEvent> GetMutatingEvents()
        {
            return this.mutatingEvents.ToArray();
        }

        void When(IDomainEvent e)
        {
            (this as dynamic).Apply(e);
        }

        protected void Apply(IDomainEvent e)
        {
            this.mutatingEvents.Add(e);
            When(e);
        }
    }
}
