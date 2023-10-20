using AttributeRouting.Web.Http;
using Core.Application.Data.ExploreApps;
using Invoice.Application;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PaaApi.Controllers
{
    public class InvoicesController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/invoices")]
        public HttpResponseMessage GetAllInvoices()
        {
            HttpResponseMessage response;
            try
            {
                InvoiceQueryService queryService = new InvoiceQueryService();
                List<InvoiceData> invoices = queryService.GetAll();
                if (invoices != null && invoices.Count > 0)
                {
                    string jsonContent = JsonConvert.SerializeObject(invoices);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = "Invoices were not found";
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(message)
                    };
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/invoices/{id}")]
        public HttpResponseMessage GetInvoiceById(string id)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceQueryService queryService = new InvoiceQueryService();
                InvoiceData invoice = queryService.Get(id);
                if (invoice != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(invoice);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Invoice with id {0} was not found", id);
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(message)
                    };
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/invoices/query/tz/{timezone}/year/{year}/month/{month}")]
        public HttpResponseMessage GetInvoiceByYearAndMonth(int year, int month, string timezone)
        {
            HttpResponseMessage response;
            try
            {
                timezone = timezone.Replace("!", "/");

                InvoiceQueryService queryService = new InvoiceQueryService();
                List<InvoiceData> invoices = queryService.GetByYearAndMonth(year, month, timezone);
                string jsonContent = JsonConvert.SerializeObject(invoices);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/invoices/query/maxinvoicedate")]
        public HttpResponseMessage GetMaxInvoiceDate()
        {
            HttpResponseMessage response;
            try
            {
                InvoiceQueryService queryService = new InvoiceQueryService();
                DateTime maxInvoiceDate = queryService.GetMaxInvoiceDate();
                string jsonContent = JsonConvert.SerializeObject(maxInvoiceDate);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/invoices/query/maxinvoicenumber/tz/{timezone}/year/{year}/month/{month}")]
        public HttpResponseMessage GetMaxInvoiceNumberByYearAndMonth(int year, int month, string timezone)
        {
            HttpResponseMessage response;
            try
            {
                timezone = timezone.Replace("!", "/");

                InvoiceQueryService queryService = new InvoiceQueryService();
                int maxInvoiceNumber = queryService.GetMaxInvoiceNumberByYearAndMonth(year, month, timezone);
                string jsonContent = JsonConvert.SerializeObject(maxInvoiceNumber);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/invoices/query/invoicecount/tz/{timezone}/year/{year}/month/{month}")]
        public HttpResponseMessage GetInvoiceCountByYearAndMonth(int year, int month, string timezone)
        {
            HttpResponseMessage response;
            try
            {
                timezone = timezone.Replace("!", "/");

                InvoiceQueryService queryService = new InvoiceQueryService();
                int invoiceCount = queryService.GetInvoiceCountByYearAndMonth(year, month, timezone);
                string jsonContent = JsonConvert.SerializeObject(invoiceCount);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/invoices/query/billingvalidationstats/tz/{timezone}/year/{year}/month/{month}")]
        public HttpResponseMessage GetBillingValidationStats(int year, int month, string timezone)
        {
            HttpResponseMessage response;
            try
            {
                timezone = timezone.Replace("!", "/");

                InvoiceQueryService queryService = new InvoiceQueryService();
                BillingValidationStatsData data = queryService.GetBillingValidationStats(year, month, timezone);
                string jsonContent = JsonConvert.SerializeObject(data);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/invoices")]
        public HttpResponseMessage NewInvoice(NewInvoiceCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceApplicationService applicationService = new InvoiceApplicationService();
                string id = applicationService.NewInvoice(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(id)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/invoices/saveactionstatus")]
        public HttpResponseMessage SaveInvoiceActionStatus(SaveInvoiceCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceApplicationService applicationService = new InvoiceApplicationService();
                applicationService.SaveInvoiceActionStatus(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/invoices/save")]
        public HttpResponseMessage SaveInvoice(SaveInvoiceCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceApplicationService applicationService = new InvoiceApplicationService();
                applicationService.SaveInvoice(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/invoices/multisave")]
        public HttpResponseMessage MultiSaveInvoice(MultiSaveInvoiceCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceApplicationService applicationService = new InvoiceApplicationService();
                applicationService.MultiSaveInvoice(commandList);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/invoices/remove")]
        public HttpResponseMessage RemoveInvoice(RemoveInvoiceCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceApplicationService applicationService = new InvoiceApplicationService();
                applicationService.RemoveInvoice(command);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/invoices/multiremove")]
        public HttpResponseMessage MultiRemoveInvoice(MultiRemoveInvoiceCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceApplicationService applicationService = new InvoiceApplicationService();
                applicationService.MultiRemoveInvoice(commandList);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpPost]
        [POST("api/invoices/search")]
        public HttpResponseMessage SearchInvoice(SearchInvoiceCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceQueryService queryService = new InvoiceQueryService();
                List<InvoiceData> invoices = queryService.SearchInvoice(command);
                string jsonContent = JsonConvert.SerializeObject(invoices);
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request,
                    Content = new StringContent(jsonContent)
                };
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };
            }
            return response;
        }

        [HttpGet]
        [GET("api/invoices/schedule/updatestatus/daily")]
        public HttpResponseMessage ScheduleUpdateInvoiceStatusDaily()
        {
            HttpResponseMessage response;
            try
            {
                _logger.Info("Starting schedule update status...");
                InvoiceApplicationService applicationService = new InvoiceApplicationService();
                applicationService.ScheduleUpdateInvoiceStatusDaily();
                response = new HttpResponseMessage(HttpStatusCode.Accepted)
                {
                    RequestMessage = Request
                };
                _logger.Info("Schedule update status finished.");
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    RequestMessage = Request,
                    Content = new StringContent(ex.ToString())
                };

                _logger.Error(new StringContent(ex.ToString()));
            }
            return response;
        }

    }
}
