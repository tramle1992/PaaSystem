using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaaApplication.Views;

namespace PaaApplication.Presenters
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view)
            : base(view)
        {

        }

        public void Login()
        {
            string userName = View.Username;
            string password = View.Password;
            Model.Login(userName, password);
        }
    }
}
