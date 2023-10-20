using Core.Domain.Model.ClientInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Application.Data.ClientInfo
{
    public class CreditTypeData
    {
        public int Value { get; set; }

        public string DisplayName { get; set; }

        public CreditTypeData()
        {
        }

        public static List<CreditTypeData> GetListCreditTypes()
        {
            List<CreditTypeData> lst = new List<CreditTypeData>();
            try
            {
                for (int i = 0; i <= 4; i++)
                {
                    CreditTypeData data = new CreditTypeData();
                    data.Value = i;
                    switch (i)
                    {
                        case 0:
                            data.DisplayName = CreditType.RegularCreditReports.DisplayName;
                            break;
                        case 1:
                            data.DisplayName = CreditType.EnhancePeopleSearch.DisplayName;
                            break;
                        case 2:
                            data.DisplayName = CreditType.NoCreditReports.DisplayName;
                            break;
                        case 3:
                            data.DisplayName = CreditType.CreditAndFICOScore.DisplayName;
                            break;
                        case 4:
                            data.DisplayName = "";
                            break;
                    }

                    lst.Add(data);
                }
            }
            catch (Exception ex)
            {
                lst = new List<CreditTypeData>();
            }
            return lst;
        }
    }
}
