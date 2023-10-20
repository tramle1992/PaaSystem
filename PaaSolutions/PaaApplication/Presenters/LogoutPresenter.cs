using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaaApplication.Views;

namespace PaaApplication.Presenters
{
    public class LogoutPresenter : Presenter<IView>
    {
        public LogoutPresenter(IView view)
            : base(view)
        {

        }

        public void Logout()
        {
            Model.Logout();
        }
    }
}
