using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Views
{
    public interface ICientInfoView : IView
    {
        string id { get; }
        string name { get; }
    }
   
}
