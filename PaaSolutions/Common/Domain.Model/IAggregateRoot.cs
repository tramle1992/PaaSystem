using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    // Aggregate: a cluster of associated objects that are treated as a unit for purpose of data changes.
    // External references are restricted to one member of the Aggregate, designated as the root.
    // A set of consistency rules applies within the Aggregate boundaries
    public interface IAggregateRoot
    {
    }
}
