using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Views
{
    public interface IResourceView : IView
    {        
        string ResourceId { get; }
        string ResourceTypeId { get; }
        string ItemName { get; }
        string Website { get; }
        string Note { get; }        
    }
}
