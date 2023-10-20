using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Models
{
    public static class EventBus
    {
        private static List<Action<object>> handlers = new List<Action<object>>();

        public static void Subscribe(Action<object> handler)
        {
            handlers.Add(handler);
        }

        public static void Publish(object e)
        {
            handlers.ForEach(handler => handler(e));
        }
    }
}
