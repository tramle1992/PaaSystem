using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastructure.ExploreApps;
using Core.Infrastructure.ClientInfo;
using Core.Application.Command.ExploreApps;
using Core.Application.Data.ExploreApps;
using Core.Domain.Model.ExploreApps;
using Core.Domain.Model.ClientInfo;
using Common.Application;

namespace Core.Application
{
    public class ExploreAppsApplicationService
    {
        readonly AppRepository appRepository;
        readonly ReportTypeRepository reportTypeRepository;
        readonly ClientRepository clientRepository;

        public ExploreAppsApplicationService()
        {
            appRepository = new AppRepository();
            reportTypeRepository = new ReportTypeRepository();
            clientRepository = new ClientRepository();
        }

        public void DeleteApp(string id)
        {
            appRepository.Remove(id);
        }

        public string NewApp(NewAppCommand command)
        {
            AppData data = command.App;
            App app = AutoMapper.Mapper.Map<AppData, App>(data);
            appRepository.Add(app);
            return app.ApplicationId.Id;
        }

        public string SaveApp(SaveAppCommand command)
        {
            AppData data = command.App;
            App app = AutoMapper.Mapper.Map<AppData, App>(data);
            appRepository.Update(app);
            return app.ApplicationId.Id;
        }

        public void MarkAsRoommates(MarkAsRoommatesCommand command)
        {
            List<string> ids = command.RoommateIds;
            List<App> apps = new List<App>();
            List<string> lastNames = new List<string>();

            string unit = "";
            string rent = "";
            string moveIn = "";
            string invoiceDivision = "";
            string clientApplied = "";

            bool roommateType = false;
            bool skipFirst = true;

            if (ids.Count < 2)
            {
                throw new InvalidOperationException("You must select at least 2 applications to mark as roomates.");
            }

            foreach (string id in ids)
            {
                App app = appRepository.Find(id);
                if (app != null)
                {
                    apps.Add(app);
                }
            }

            List<string> clientIds = apps.Select(o => o.ClientApplied.Id).Distinct().ToList();
            if (clientIds.Count > 1)
            {
                throw new InvalidOperationException("Roommates must being processed for same client");
            }

            Client currentClient = clientRepository.Find(clientIds.ElementAt(0));

            foreach (App app in apps)
            {
                if (app != null)
                {

                    lastNames.Add(app.LastName);
                    if (string.IsNullOrEmpty(clientApplied))
                    {
                        clientApplied = app.ClientApplied.Id;
                    }
                    if (string.IsNullOrEmpty(unit) && (!string.IsNullOrEmpty(app.UnitNumber) && app.UnitNumber != "N/A"))
                    {
                        unit = app.UnitNumber;
                    }
                    if (string.IsNullOrEmpty(rent) && (!string.IsNullOrEmpty(app.RentAmount) && app.RentAmount != "N/A"))
                    {
                        rent = app.RentAmount;
                    }
                    if (string.IsNullOrEmpty(moveIn) && (!string.IsNullOrEmpty(app.MoveInDate) && app.MoveInDate != "N/A"))
                    {
                        moveIn = app.MoveInDate;
                    }
                    if (!string.IsNullOrEmpty(app.InvoiceDivision) && !app.InvoiceDivision.Equals("(None)"))
                    {
                        invoiceDivision = app.InvoiceDivision;
                    }
                }
            }

            List<ReportType> reportTypes = reportTypeRepository.FindAll();

            ReportType roommateReportType = reportTypes.Find(r => r.TypeName == GlobalConstants.Roommate);

            if (roommateReportType == null) 
                throw new InvalidOperationException("Can not mark apps as roommates because Report type 'Roommate' does not exist. Please check and try again.");

            decimal roommateDefaultPrice = roommateReportType.DefaultPrice;
            decimal roommateSpecialPrice = roommateDefaultPrice;

            ClientReportSpecialPrice specialPrice = currentClient.ClientReportSpecialPrices.SingleOrDefault(c => c.ReportTypeId == roommateReportType.ReportTypeId);
            if (specialPrice == null)
            {
                roommateType = false;
            }
            else if (roommateDefaultPrice != specialPrice.SpecialPrice)
            {
                roommateType = true;
            }

            foreach (App app in apps)
            {
                ReportType reportType = reportTypes.Find(r => r.ReportTypeId == app.ReportTypeId.Id);
                if (reportType.AbsoluteTypeName != GlobalConstants.Residential)
                {
                    throw new InvalidOperationException("Only Full Residential screenings can be marked as roommates.");
                }
                if (string.IsNullOrEmpty(app.UnitNumber) || app.UnitNumber == "N/A")
                {
                    app.UnitNumber = unit;
                }
                if (string.IsNullOrEmpty(app.RentAmount) || app.RentAmount == "N/A")
                {
                    app.RentAmount = rent;
                }
                if (string.IsNullOrEmpty(app.MoveInDate) || app.MoveInDate == "N/A")
                {
                    app.MoveInDate = moveIn;
                }
                if (!string.IsNullOrEmpty(invoiceDivision))
                {
                    app.InvoiceDivision = invoiceDivision;
                }

                if (roommateType == true)
                {
                    if (skipFirst == true)
                        skipFirst = false;
                    else
                    {
                        app.ReportTypeId = new ReportTypeId(roommateReportType.ReportTypeId);
                    }
                }
            }

            foreach (App app in apps)
            {
                var names = new List<string>();

                foreach (var item in apps)
                {
                    if (item.ApplicationId == app.ApplicationId) continue;
                    if (string.IsNullOrEmpty(item.LastName) && string.IsNullOrEmpty(item.FirstName)) continue;

                    if (string.IsNullOrEmpty(item.LastName)) names.Add(item.FirstName);
                    else if (string.IsNullOrEmpty(item.FirstName)) names.Add(item.LastName);
                    else names.Add(string.Format("{0} {1}", item.FirstName, item.LastName));
                }

                string roommates = "W/ " + string.Join(", ", names);
                app.ReportSpecialField = roommates;
                appRepository.Update(app);
            }
        }

    }
}
