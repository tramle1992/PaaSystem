using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaaApplication.Models;
using PaaApplication.Views;

namespace PaaApplication.Presenters
{
    public class Presenter<T> where T : IView
    {
        protected static IModel Model { get; private set; }
        protected T View { get; private set; }

        static Presenter()
        {
            
        }

        public Presenter(T view)
        {
            View = view;
        }

    }
}
