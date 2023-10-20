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
    public class PaymentsController : ApiController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [GET("api/payments")]
        public HttpResponseMessage GetAllPayments()
        {
            HttpResponseMessage response;
            try
            {
                PaymentQueryService queryService = new PaymentQueryService();
                List<PaymentData> payments = queryService.GetAll();
                if (payments != null && payments.Count > 0)
                {
                    string jsonContent = JsonConvert.SerializeObject(payments);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = "Payments were not found";
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
        [GET("api/payments/invoice/{id}")]
        public HttpResponseMessage GetPaymentsByInvoiceId(string id)
        {
            HttpResponseMessage response;
            try
            {
                PaymentQueryService queryService = new PaymentQueryService();
                List<PaymentData> payments = queryService.GetByInvoiceId(id);
                string jsonContent = JsonConvert.SerializeObject(payments);
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
        [GET("api/payments/{id}")]
        public HttpResponseMessage GetPaymentById(string id)
        {
            HttpResponseMessage response;
            try
            {
                PaymentQueryService queryService = new PaymentQueryService();
                PaymentData payment = queryService.Get(id);
                if (payment != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(payment);
                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                        Content = new StringContent(jsonContent)
                    };
                }
                else
                {
                    string message = string.Format("Payment with id {0} was not found", id);
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
        [POST("api/payments")]
        public HttpResponseMessage NewPayment(NewPaymentCommand command)
        {
            HttpResponseMessage response;
            try
            {
                PaymentApplicationService applicationService = new PaymentApplicationService();
                string id = applicationService.NewPayment(command);
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

        [HttpPut]
        [PUT("api/payments")]
        public HttpResponseMessage SavePayment(SavePaymentCommand command)
        {
            HttpResponseMessage response;
            try
            {
                PaymentApplicationService applicationService = new PaymentApplicationService();
                applicationService.SavePayment(command);
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
        [POST("api/payments/remove")]
        public HttpResponseMessage RemovePayment(RemovePaymentCommand command)
        {
            HttpResponseMessage response;
            try
            {
                PaymentApplicationService applicationService = new PaymentApplicationService();
                applicationService.RemovePayment(command);
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
        [POST("api/payments/removebyinvoiceid")]
        public HttpResponseMessage RemovePaymentByInvoiceId(RemovePaymentByInvoiceIdCommand command)
        {
            HttpResponseMessage response;
            try
            {
                PaymentApplicationService applicationService = new PaymentApplicationService();
                applicationService.RemovePaymentByInvoiceId(command);
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
        [POST("api/payments/multiremovebyinvoiceid")]
        public HttpResponseMessage MultiRemovePaymentByInvoiceId(MultiRemovePaymentByInvoiceIdCommand commandList)
        {
            HttpResponseMessage response;
            try
            {
                PaymentApplicationService applicationService = new PaymentApplicationService();
                applicationService.MultiRemovePaymentByInvoiceId(commandList);
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
