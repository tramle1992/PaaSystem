using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaaApplication.Views;
using PaaApplication.Models;

namespace PaaApplication.Presenters
{
    public class TimecardPresenter : Presenter<ITimecardView>
    {
        public TimecardPresenter(ITimecardView view)
            : base(view)
        {

        }

        public List<Timecard> GetAllTimecards()
        {
            return Model.GetAllTimecards();
        }
    }
}
