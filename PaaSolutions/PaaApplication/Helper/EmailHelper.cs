using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaaApplication.Helper
{
    public class EmailHelper
    {
        public static string BuildSignature(List<string> applicantName = null)
        {
            string appliName = "Attached are screening report(s) for:";
            if (applicantName != null)
            {
                foreach (var appName in applicantName)
                {
                    appliName += string.Format("<br /> {0}", appName);
                }
                if (applicantName.Count == 0)
                {
                    appliName = "";
                }
            }
            else
            {
                appliName = string.Empty;
            }
            string signature = string.Format(@"{0}<br/><br/><br/><br/><br/><p>
<strong>We moved!</strong><br /><br />
<strong>Bemrose Consulting, Inc.</strong><br /><br />
<strong>9115 SW Oleson Rd, Ste 303</strong><br /><br />
<strong>Portland, OR 97223</strong><br /><br />
<strong>Bemrose Consulting, Inc.</strong><br />

                                Professional Tenant and Employee Screening<br />
                                (503) 419-6539; (800) 886-3365</p>

                                <p>This is a confidential document, intended solely for the person to whom it is addressed.&nbsp;If you receive this document in error, please contact us at the numbers above, and then destroy this document.&nbsp;Thank you.</p>

                                <p>&nbsp;</p>", appliName);

            return signature;


        }
    }
}
