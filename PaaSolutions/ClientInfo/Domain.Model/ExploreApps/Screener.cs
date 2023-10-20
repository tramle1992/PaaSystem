using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;
using IdentityAccess.Domain.Model.Identity;

namespace Core.Domain.Model.ExploreApps
{
    public class Screener : ValueObject
    {
        public string ScreenerId { get; set; }

        public string ScreenerName { get; set; }

        private Screener()
        { }

        public Screener(string id, string name)
        {
            this.ScreenerId = id;
            this.ScreenerName = name;
        }

        public Screener(Screener screener) : this(screener.ScreenerId, screener.ScreenerName)
        {
        }

        public static Screener FromUser(User user)
        {
            return new Screener(user.UserId.Id, user.UserName);
        }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return this.ScreenerId;
            yield return this.ScreenerName;
        }

        public override string ToString()
        {
            return "Screener[screenerId=" + this.ScreenerId
                + ", screenerName=" + this.ScreenerName + "]";
        }
    }
}
