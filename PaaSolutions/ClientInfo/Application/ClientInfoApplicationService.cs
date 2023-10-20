using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Data;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using Core.Domain.Model.ClientInfo;
using Core.Application.Command.ClientInfo;
using Common.Infrastructure.Query;
using System.Data;
using Dapper;

namespace Core.Application
{
    public class ClientInfoApplicationService : QueryService
    {
        public ClientInfoApplicationService()
        {
            this.managementCompanyRepository = new ManagementCompanyRepository();
            this.reportTypeRepository = new ReportTypeRepository();
            this.clientRepository = new ClientRepository();
        }

        readonly ManagementCompanyRepository managementCompanyRepository;
        readonly ReportTypeRepository reportTypeRepository;
        readonly ClientRepository clientRepository;

        public string NewManagementCompany(NewManagementCompanyCommand command)
        {
            ManagementCompanyId id = new ManagementCompanyId(Guid.NewGuid().ToString());
            ManagementCompany managementCompany = new ManagementCompany(id, command.Name);
            managementCompanyRepository.Add(managementCompany);
            return managementCompany.ManagementCompanyId.Id;
        }

        public void SaveManagementCompany(SaveManagementCompanyCommand command)
        {
            ManagementCompany managementCompany = managementCompanyRepository.Find(command.ManagementCompanyId);
            managementCompany.ChangeName(command.ManagementCompanyName);
            managementCompanyRepository.Update(managementCompany);
        }

        public string NewReportType(NewReportTypeCommand command)
        {
            string id = Guid.NewGuid().ToString();
            ReportType reportType = new ReportType(id, command.TypeName, command.AbsoluteTypeName, command.DefaultPrice);
            reportTypeRepository.Add(reportType);
            return reportType.ReportTypeId;
        }

        public void SaveReportType(SaveReportTypeCommand command)
        {
            ReportType reportType = reportTypeRepository.Find(command.ReportTypeId);
            reportType.ChangeTypeName(command.TypeName);
            reportType.ChangeAbsoluteName(command.AbsoluteTypeName);
            reportType.ChangeDefaultPrice(command.DefaultPrice);

            reportTypeRepository.Update(reportType);
        }

        public void DeleteReportType(string id)
        {
            reportTypeRepository.Remove(id);
        }

        public string NewClient(NewClientCommand command)
        {
            ClientData clientData = command.ClientData;
            ClientId id = new ClientId(Guid.NewGuid().ToString());
            Client client = new Client(id, clientData.ClientName);

            try
            {   
                client.CustomerNumber = clientData.CustomerNumber;
                client.BillingAddress = clientData.BillingAddress;
                client.Phone = clientData.Phone;
                client.Fax = clientData.Fax;
                client.Email = clientData.Email;
                client.Since = DateTime.UtcNow;
                client.BillingInfo = clientData.BillingInfo;
                client.MiscComments = clientData.MiscComments;
                if (command.ClientData.ManagementCompany != null)
                {
                    client.ManagementCompany = ClientInfoObjectConversionService.ToManagementCompany(clientData.ManagementCompany);
                }
                client.ClientRevoked = clientData.ClientRevoked;
                ClientReceive clientReceive = new ClientReceive(
                    clientData.DeclinationLetter,
                    clientData.InvoicesCopiesNumber,
                    clientData.Credentialed
                );

                if (clientData.CreditType == null)
                {
                    client.CreditType = null;
                }
                else
                {
                    CreditType creditType = new CreditType(clientData.CreditType.Value, clientData.CreditType.DisplayName);

                    client.CreditType = creditType;
                }

                client.ClientReceive = clientReceive;
                client.DefaultDeliverConfirmationsTo = clientData.DefaultDeliverConfirmationsTo;
                client.DefaultVerifyConfirmDelivery = clientData.DefaultVerifyConfirmDelivery;
                client.DefaultDeliverReportsTo = clientData.DefaultDeliverReportsTo;
                client.DefaultDeliverInvoicesTo = clientData.DefaultDeliverInvoicesTo;
                client.SpecialEntryInfo = clientData.SpecialEntryInfo;
                client.SpecialCriteriaInfo = clientData.SpecialCriteriaInfo;
                client.WebInfo = new WebInfo(clientData.WebsiteDir, clientData.WebPass);
                foreach (OtherAddressData data in clientData.OtherAddresses)
                {
                    client.OtherAddresses.Add(ClientInfoObjectConversionService.ToOtherAddress(data));
                }
                foreach (ContactData data in clientData.Contacts)
                {
                    client.Contacts.Add(ClientInfoObjectConversionService.ToContact(data));
                }
                foreach (InvoiceDivisionData data in clientData.InvoiceDivisions)
                {
                    client.InvoiceDivisions.Add(ClientInfoObjectConversionService.ToInvoiceDivision(data));
                }
                foreach (ClientReportSpecialPriceData data in clientData.ClientReportSpecialPrices)
                {
                    client.ClientReportSpecialPrices.Add(ClientInfoObjectConversionService.ToClientReportSpecialPrice(data));
                }

                clientRepository.Add(client);
            }
            catch (Exception ex)
            {

            }           

            return client.ClientId.Id;
        }

        public void SaveClient(SaveClientCommand command)
        {
            try
            {
                ClientData clientData = command.ClientData;
                Client client = clientRepository.Find(command.ClientId);
                client.ChangeName(clientData.ClientName);
                client.CustomerNumber = clientData.CustomerNumber;
                client.BillingAddress = clientData.BillingAddress;
                client.Phone = clientData.Phone;
                client.Fax = clientData.Fax;
                client.Email = clientData.Email;
                client.Since = command.ClientData.Since;
                client.BillingInfo = clientData.BillingInfo;
                client.MiscComments = clientData.MiscComments;
                client.ReportTypeId = new ReportTypeId(clientData.DefaultReportTypeId);
                if (command.ClientData.ManagementCompany != null)
                {
                    client.ManagementCompany = ClientInfoObjectConversionService.ToManagementCompany(clientData.ManagementCompany);
                }
                client.ClientRevoked = clientData.ClientRevoked;
                ClientReceive clientReceive = new ClientReceive(
                    clientData.DeclinationLetter,
                    clientData.InvoicesCopiesNumber,
                    clientData.Credentialed
                );

                CreditType creditType = new CreditType(clientData.CreditType.Value, clientData.CreditType.DisplayName);
                client.CreditType = creditType;

                client.ClientReceive = clientReceive;
                client.DefaultDeliverConfirmationsTo = clientData.DefaultDeliverConfirmationsTo;
                client.DefaultVerifyConfirmDelivery = clientData.DefaultVerifyConfirmDelivery;
                client.DefaultDeliverReportsTo = clientData.DefaultDeliverReportsTo;
                client.DefaultDeliverInvoicesTo = clientData.DefaultDeliverInvoicesTo;
                client.SpecialEntryInfo = clientData.SpecialEntryInfo;
                client.SpecialCriteriaInfo = clientData.SpecialCriteriaInfo;
                client.WebInfo = new WebInfo(clientData.WebsiteDir, clientData.WebPass);
                client.OtherAddresses.Clear();
                foreach (OtherAddressData data in clientData.OtherAddresses)
                {
                    client.OtherAddresses.Add(ClientInfoObjectConversionService.ToOtherAddress(data));
                }
                client.Contacts.Clear();
                foreach (ContactData data in clientData.Contacts)
                {
                    client.Contacts.Add(ClientInfoObjectConversionService.ToContact(data));
                }
                client.InvoiceDivisions.Clear();
                foreach (InvoiceDivisionData data in clientData.InvoiceDivisions)
                {
                    client.InvoiceDivisions.Add(ClientInfoObjectConversionService.ToInvoiceDivision(data));
                }
                client.ClientReportSpecialPrices.Clear();
                foreach (ClientReportSpecialPriceData data in clientData.ClientReportSpecialPrices)
                {
                    client.ClientReportSpecialPrices.Add(ClientInfoObjectConversionService.ToClientReportSpecialPrice(data));
                }

                clientRepository.Update(client);
            }
            catch (Exception ex)
            {
                
            }
            
        }

        public void SaveMultiClient(SaveMultiClientCommand commandList)
        {
            foreach (SaveClientCommand command in commandList.CommandList)
            {
                SaveClient(command);
            }
        }

        public void DeleteClient(string id)
        {
            clientRepository.Delete(id);
        }

        public void UpdateWideManagementInfo(SaveWideMgtInfoCommand command)
        {
            ManagementWideInfoUpdates mgtWideUpdates = new ManagementWideInfoUpdates();
           
            mgtWideUpdates.SetClause = command.SetClause;
            mgtWideUpdates.ManagementCompanyData = command.ManagementCompanyData;

            clientRepository.UpdateWideManagementInfo(mgtWideUpdates);
        }

    }
}
