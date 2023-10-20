using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Newtonsoft.Json;
using AttributeRouting;
using Core.Application;
using Core.Application.Data.ClientInfo;
using Core.Infrastructure.ClientInfo;
using AutoDocument.Application;
using AutoDocument.Application.Data;
using Core.Application.Command.ClientInfo;
using Core.Domain.Model.ClientInfo;


namespace PaaApi.Controllers
{
    public class DisplayInfoController : ApiController
    {
        [HttpGet]
        [GET("api/displayinfo/clients")]
        public HttpResponseMessage GetClientDisplayInfo()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<ClientDisplayInfoData> lstClient = (List<ClientDisplayInfoData>)clientInfoQueryService.GetAllClientDisplayInfoData();
                string jsonContent = JsonConvert.SerializeObject(lstClient);
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
        [GET("api/displaymailinfo/clients")]
        public HttpResponseMessage GetClientMailsDisplayInfo()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<ClientMailsDisplayInfoData> lstClient = (List<ClientMailsDisplayInfoData>)clientInfoQueryService.GetAllClientMailInfoData();
                string jsonContent = JsonConvert.SerializeObject(lstClient);
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
        [GET("api/mgtcompany/clients")]
        public HttpResponseMessage GetClientMgtCompanyDisplayInfo()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<ManagementCompanyData> lst = (List<ManagementCompanyData>)clientInfoQueryService.GetAllManagementCompany();
                string jsonContent = JsonConvert.SerializeObject(lst);
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
        [GET("api/displayinfo/users")]
        public HttpResponseMessage GetUserDisplayInfo()
        {
            HttpResponseMessage response;
            try
            {
                DocumentReportQueryService documentReportQueryService = new DocumentReportQueryService();
                List<UserDisplayInfoData> lstClient = (List<UserDisplayInfoData>)documentReportQueryService.GetAllUsers();
                string jsonContent = JsonConvert.SerializeObject(lstClient);
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
        [GET("api/displayinfo/customernumber")]
        public HttpResponseMessage GetCustomerNumberDisplayInfo()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<string> lstCustomerNumber = (List<string>)clientInfoQueryService.GetAllCustomerNumber();
                string jsonContent = JsonConvert.SerializeObject(lstCustomerNumber);
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
        [GET("api/displayinfo/invoicedivision")]
        public HttpResponseMessage GetInvoiceDivisionDisplayInfo()
        {
            HttpResponseMessage response;
            try
            {
                ClientInfoQueryService clientInfoQueryService = new ClientInfoQueryService();
                List<string> lstInvoiceDivision = (List<string>)clientInfoQueryService.GetAllInvoiceDivision();
                string jsonContent = JsonConvert.SerializeObject(lstInvoiceDivision);
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

        [GET("api/displayinfo/newcustno/{letter}")]
        public HttpResponseMessage GetNewCustomerNumber(string letter)
        {
            HttpResponseMessage response;
            CustomerNumberRespository customerNumberRepository = new CustomerNumberRespository();
            try
            {
                string newCustNo = "";
                if (!string.IsNullOrEmpty(letter))
                {
                    if (letter.Length > 1)
                    {
                        letter = letter[0].ToString();
                    }

                    letter = letter.ToUpper();
                    newCustNo = customerNumberRepository.GenerateNewCustomerNumber(letter);

                    if (!string.IsNullOrEmpty(newCustNo))
                    {
                        response = new HttpResponseMessage(HttpStatusCode.Accepted)
                        {
                            RequestMessage = Request,
                            Content = new StringContent(newCustNo)
                        };
                    }
                    else
                    {
                        string message = string.Format("Can not generate new Customer Number ");
                        HttpError httpError = new HttpError(message);
                        response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                    }
                }
                else
                {
                    string message = string.Format("Request Value is Null or Empty");
                    HttpError httpError = new HttpError(message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                }
            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

        [HttpPut]
        [PUT("api/displayinfo/newcustno/{letter}")]
        public HttpResponseMessage UpdateCustomerNumber(string letter, SaveCustomerNumerCommand command)
        {
            HttpResponseMessage response;
            CustomerNumberRespository customerNumberRepository = new CustomerNumberRespository();
            try
            {
                if (!string.IsNullOrEmpty(letter))
                {
                    if (letter.Length > 1)
                    {
                        letter = letter[0].ToString();
                    }

                    letter = letter.ToUpper();

                    CustomerNumberSetting customer = new CustomerNumberSetting();

                    customer.LastNumber = command.LastNumber;
                    customer.Letter = letter[0];

                    customerNumberRepository.Update(customer);

                    response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    {
                        RequestMessage = Request,
                    };

                }
                else
                {
                    string message = string.Format("Request Value is Null or Empty");
                    HttpError httpError = new HttpError(message);
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
                }

            }
            catch (Exception ex)
            {
                HttpError httpError = new HttpError(ex, false);
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
                throw new HttpResponseException(response);
            }
            return response;
        }

    }
}
