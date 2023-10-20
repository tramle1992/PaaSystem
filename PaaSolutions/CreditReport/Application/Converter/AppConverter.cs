using System.Collections.Generic;
using System.Linq;
using System;
using Core.Application.Data.ExploreApps;
#if PRODUCTION_DEPLOY
using TuStd = MicrobiltPortAdapter.ProductionTuStd;
#else
using TuStd = MicrobiltPortAdapter.StagingTuStd;
#endif

namespace CreditReport.Application.Converter
{
    public static class AppConverter
    {
        public static RentalRefData FromPostAddr(TuStd.PostAddr_Type postAddr)
        {
            if (postAddr == null || postAddr.Items == null || postAddr.Items.Length == 0)
                return null;

            var rentalRef = new RentalRefData();

            // Set default values
            rentalRef.MoveIn = "";
            rentalRef.MoveOut = "";
            rentalRef.Amount = "";
            rentalRef.Written = RentalRefFactInfoData.NotAvailable;
            rentalRef.KickedOut = RentalRefFactInfoData.NotAvailable;
            rentalRef.PrprNotice = RentalRefFactInfoData.NotAvailable;
            rentalRef.LateNSF = RentalRefFactInfoData.NotAvailable;
            rentalRef.Complaints = RentalRefFactInfoData.NotAvailable;
            rentalRef.Damages = RentalRefFactInfoData.NotAvailable;
            rentalRef.BedBugs = RentalRefFactInfoData.NotAvailable;
            rentalRef.Owing = RentalRefFactInfoData.NotAvailable;
            rentalRef.Roommates = RentalRefFactInfoData.NotAvailable;
            rentalRef.AddressMatch = RentalRefFactInfoData.NotAvailable;
            rentalRef.Pets = RentalRefFactInfoData.NotAvailable;
            rentalRef.ReRent = RentalRefFactInfoData.NotAvailable;
            rentalRef.RltveFrnd = RentalRefFactInfoData.NotAvailable;

            var streetLineArr = new List<string>();
            if (postAddr.ItemsElementName.Contains(TuStd.ItemsChoiceType1.StreetNum))
            {
                streetLineArr.Add(postAddr.Items.ElementAt(Array.IndexOf(postAddr.ItemsElementName, TuStd.ItemsChoiceType1.StreetNum)));
            }
            if (postAddr.ItemsElementName.Contains(TuStd.ItemsChoiceType1.PreDirection))
            {
                streetLineArr.Add(postAddr.Items.ElementAt(Array.IndexOf(postAddr.ItemsElementName, TuStd.ItemsChoiceType1.PreDirection)));
            }
            if (postAddr.ItemsElementName.Contains(TuStd.ItemsChoiceType1.StreetName))
            {
                streetLineArr.Add(UppercaseWords(postAddr.Items.ElementAt(Array.IndexOf(postAddr.ItemsElementName, TuStd.ItemsChoiceType1.StreetName)).ToLower()));
            }
            if (postAddr.ItemsElementName.Contains(TuStd.ItemsChoiceType1.StreetType))
            {
                streetLineArr.Add(postAddr.Items.ElementAt(Array.IndexOf(postAddr.ItemsElementName, TuStd.ItemsChoiceType1.StreetType)));
            }
            if (postAddr.ItemsElementName.Contains(TuStd.ItemsChoiceType1.PostDirection))
            {
                streetLineArr.Add(postAddr.Items.ElementAt(Array.IndexOf(postAddr.ItemsElementName, TuStd.ItemsChoiceType1.PostDirection)));
            }

            var secondaryUnitArr = new List<string>();
            if (postAddr.ItemsElementName.Contains(TuStd.ItemsChoiceType1.UnitType))
            {
                var unitType = postAddr.Items.ElementAt(Array.IndexOf(postAddr.ItemsElementName, TuStd.ItemsChoiceType1.UnitType));
                if (!string.IsNullOrEmpty(unitType))
                {
                    secondaryUnitArr.Add(unitType);
                }
            }
            if (postAddr.ItemsElementName.Contains(TuStd.ItemsChoiceType1.Apt))
            {
                var apt = postAddr.Items.ElementAt(Array.IndexOf(postAddr.ItemsElementName, TuStd.ItemsChoiceType1.Apt));
                if (!string.IsNullOrEmpty(apt))
                {
                    secondaryUnitArr.Add(apt);
                }
            }

            string streetLine = string.Join(" ", streetLineArr);

            if (secondaryUnitArr.Count == 2)
            {
                streetLine = streetLine + ", " + string.Join(" ", secondaryUnitArr);
            }
            string stateLine = UppercaseWords(postAddr.City.ToLower()) + ", " + postAddr.StateProv + " " + postAddr.PostalCode;

            rentalRef.Comment = streetLine + Environment.NewLine + stateLine;
            return rentalRef;
        }

        private static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        public static string ScoreToFinalInfoComment(TuStd.Score_Type score)
        {
            if (score == null) throw new ArgumentException("Invalid score input");

            return "FICO Score: " + score.Value.ToString();
        }

        public static bool IsLienPublicRecord(int prType)
        {
            if ((20 <= prType && prType <= 30) ||
                (46 <= prType && prType <= 47) ||
                (63 <= prType && prType <= 68) ||
                (74 <= prType && prType <= 75))
                return true;

            return false;
        }

        public static bool IsPaidOrReleasedLienPublicRecord(int prType)
        {
            if (!IsLienPublicRecord(prType))
                return false;

            if (prType == 23 || prType == 24 || prType == 26 ||
                prType == 27 || prType == 29 || prType == 31 ||
                prType == 33 || prType == 47)
                return true;

            return false;
        }

        public static bool IsJudgmentPublicRecord(int prType)
        {
            if ((41 <= prType && prType <= 43) ||
                (48 <= prType && prType <= 52) ||
                (55 == prType) ||
                (73 == prType) ||
                (84 == prType) ||
                (113 == prType) ||
                (114 == prType) ||
                (117 == prType))
                return true;
            return false;
        }

        public static bool IsPaidOrReleasedJudgmentPublicRecord(int prType)
        {
            return IsJudgmentPublicRecord(prType);
        }

        public static bool IsBankcruptcyPublicRecord(int prType)
        {
            if ((1 <= prType && prType <= 19) ||
                (97 <= prType && prType <= 98) ||
                (115 == prType) ||
                (120 <= prType && prType <= 205))
                return true;
            return false;
        }

    }
}
