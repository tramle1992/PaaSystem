using Common.Domain.Model;
using System.Text;
using System.Threading.Tasks;

namespace TimeCard.Domain.Model
{
    public class TimeCardType : Enumeration
    {
        public static readonly TimeCardType Regular = new TimeCardType(0, "Regular");

        public static readonly TimeCardType Holiday = new TimeCardType(1, "Holiday");

        public static readonly TimeCardType Vacation = new TimeCardType(2, "Vacation");

        public static readonly TimeCardType HolidayLastInOut = new TimeCardType(3, "Holiday (Last In/ Out)");

        public static readonly TimeCardType VacationLastInOut = new TimeCardType(4, "Vacation (Last In/ Out)");

        public static TimeCardType CreateInstance(int value)
        {
            switch (value)
            {
                case 0:
                    return TimeCardType.Regular;
                case 1:
                    return TimeCardType.Holiday;
                case 2:
                    return TimeCardType.Vacation;
                case 3:
                    return TimeCardType.HolidayLastInOut;
                case 4:
                    return TimeCardType.VacationLastInOut;
                default:
                    return null;
            }
        }

        public TimeCardType()
        {
        }

        public TimeCardType(int value, string displayName)
            : base(value, displayName)
        { }
    }
}
