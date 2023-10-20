using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Views
{
    public interface ITimecardView : IView
    {
        DateTime Date { get; }
        DateTime TimeInMorning { get; }
        DateTime TimeOutMorning { get; }
        DateTime TimeInAfternoon { get; }
        DateTime TimeOutAfternoon { get; }
        int Bonus { get; }
        int Hours { get; }
        int Type { get; }
    }
}
