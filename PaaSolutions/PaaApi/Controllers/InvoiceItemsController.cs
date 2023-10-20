using AttributeRouting.Web.Http;
using Invoice.Application;
using Invoice.Application.Command;
using Invoice.Application.Data;
using Invoice.Domain.Model;
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
    public class InvoiceItemsController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/invoiceitems")]
        public HttpResponseMessage GetAllInvoiceItems()
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemQueryService queryService = new InvoiceItemQueryService();
                List<InvoiceItemData> invoiceItems = queryService.GetAll();
                if (invoiceItems != null && invoiceItems.Count > 0)
                {
                    string jsonContent = JsonConvert.SerializeObject(invoiceItems);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = "Invoice Items were not found";
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
        [GET("api/invoiceitems/invoice/{id}")]
        public HttpResponseMessage GetInvoiceItemsByInvoiceId(string id)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemQueryService queryService = new InvoiceItemQueryService();
                List<InvoiceItemData> invoiceItems = queryService.GetByInvoiceId(id);
                string jsonContent = JsonConvert.SerializeObject(invoiceItems);
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
        [GET("api/invoiceitems/{id}")]
        public HttpResponseMessage GetInvoiceItemById(string id)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemQueryService queryService = new InvoiceItemQueryService();
                InvoiceItemData invoiceItem = queryService.Get(id);
                if (invoiceItem != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(invoiceItem);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Invoice Item with id {0} was not found", id);
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

        [HttpPost]
        [POST("api/invoiceitems/new")]
        public HttpResponseMessage NewInvoiceItem(NewInvoiceItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemApplicationService applicationService = new InvoiceItemApplicationService();
                string id = applicationService.NewInvoiceItem(command);
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
        [POST("api/invoiceitems/multinew")]
        public HttpResponseMessage MultiNewInvoiceItem(MultiNewInvoiceItemCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemApplicationService applicationService = new InvoiceItemApplicationService();
                applicationService.MultiNewInvoiceItem(commandList);
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

        [HttpPut]
        [PUT("api/invoiceitems/save")]
        public HttpResponseMessage SaveInvoiceItem(SaveInvoiceItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemApplicationService applicationService = new InvoiceItemApplicationService();
                applicationService.SaveInvoiceItem(command);
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
        [POST("api/invoiceitems/remove")]
        public HttpResponseMessage RemoveInvoiceItem(RemoveInvoiceItemCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemApplicationService applicationService = new InvoiceItemApplicationService();
                applicationService.RemoveInvoiceItem(command);
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
        [POST("api/invoiceitems/multiremove")]
        public HttpResponseMessage MultiRemoveInvoiceItem(MultiRemoveInvoiceItemCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemApplicationService applicationService = new InvoiceItemApplicationService();
                applicationService.MultiRemoveInvoiceItem(commandList);
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
        [POST("api/invoiceitems/removebyinvoiceid")]
        public HttpResponseMessage RemoveInvoiceItemByInvoiceId(RemoveInvoiceItemByInvoiceIdCommand command)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemApplicationService applicationService = new InvoiceItemApplicationService();
                applicationService.RemoveInvoiceItemByInvoiceId(command);
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
        [POST("api/invoiceitems/multiremovebyinvoiceid")]
        public HttpResponseMessage MultiRemoveInvoiceItemByInvoiceId(MultiRemoveInvoiceItemByInvoiceIdCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                InvoiceItemApplicationService applicationService = new InvoiceItemApplicationService();
                applicationService.MultiRemoveInvoiceItemByInvoiceId(commandList);
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

    }
}
