using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class MindTreeRefactoring
    {
        public HealthResponse HealthCheck()

        {

            HealthResponse response = new HealthResponse()

            {

                serviceName = "Internal Sales API",

                httpResponseCode = HttpStatusCode.OK,

                nestedServices = new List<NestedServices>()

            };



            Parallel.Invoke(

                        () =>

                        { CheckAudienceAndRatingsService(response); },

                        () =>

                        { CheckSmsConnection(response); },

                        () =>

                        { CheckProposalService(response); },

                        () =>

                        { CheckBOMSService(response); },

                        () =>

                        { CheckSystemTopographyService2(response); }

                    );



            if (response.nestedServices.Count > 0)

            {

                var timeOut = response.nestedServices.Where(x => x.httpResponseCode == HttpStatusCode.ServiceUnavailable).FirstOrDefault();

                if (timeOut != null)

                {

                    response.httpResponseCode = HttpStatusCode.ServiceUnavailable;

                }

                else

                {

                    response.httpResponseCode = HttpStatusCode.GatewayTimeout;

                }



                throw new ApiException(response.httpResponseCode, response.nestedServices[0].ToString(), Newtonsoft.Json.JsonConvert.SerializeObject(response));

            }

            return response;

        }



        public void CheckAudienceAndRatingsService(HealthResponse healthResponse)

        {

            NestedServices ns = new NestedServices();

            ns.serviceName = "Audience and Ratings Service";

            string message = string.Empty;



            ServiceStatus status = ServiceStatus.Open;

            Task t = Task.Run(() =>

            {

                status = _SMSClient.Handler.GetStatus();

            });



            if (!t.Wait(5000))

                message = "timeout of 5 seconds";



            if (status == ServiceStatus.Closed)

            {

                ns.httpResponseCode = HttpStatusCode.ServiceUnavailable;

                ns.message = "Audience and Ratings Service is down";

                healthResponse.nestedServices.Add(ns);

            }

            if (!string.IsNullOrEmpty(message))

            {

                ns.httpResponseCode = HttpStatusCode.GatewayTimeout;

                ns.message = "Audience and Ratings Service is " + message;

                healthResponse.nestedServices.Add(ns);

            }



        }



        public void CheckSmsConnection(HealthResponse healthResponse)

        {

            string message = string.Empty;

            NestedServices ns = new NestedServices();

            ns.serviceName = "SMS Service";

            ServiceStatus status = ServiceStatus.Open;

            Task t = Task.Run(() =>

            {

                status = _SMSClient.GetStatus();

            });



            if (!t.Wait(5000))

                message = "timeout of 5 seconds";



            if (status == ServiceStatus.Closed)

            {

                ns.httpResponseCode = HttpStatusCode.ServiceUnavailable;

                ns.message = "SMS Service  is down" + message;

                healthResponse.nestedServices.Add(ns);

            }

            if (!string.IsNullOrEmpty(message))

            {

                ns.httpResponseCode = HttpStatusCode.GatewayTimeout;

                ns.message = "SMS Service is " + message;

                healthResponse.nestedServices.Add(ns);

            }

        }



        public void CheckProposalService(HealthResponse healthResponse)

        {

            NestedServices ns = new NestedServices();

            ns.serviceName = "Proposal Service";

            string message = string.Empty;



            ServiceStatus status = ServiceStatus.Open;

            Task t = Task.Run(() =>

            {



                status = PCSClient.Handler.GetStatus();

            });



            if (!t.Wait(5000))

                message = "timeout of 5 seconds";



            if (status == ServiceStatus.Closed)

            {

                ns.httpResponseCode = HttpStatusCode.ServiceUnavailable;

                ns.message = "Proposal Service  is down";

                healthResponse.nestedServices.Add(ns);

            }

            if (!string.IsNullOrEmpty(message))

            {

                ns.httpResponseCode = HttpStatusCode.GatewayTimeout;

                ns.message = "Proposal Service is " + message;

                healthResponse.nestedServices.Add(ns);

            }

        }



        public void CheckBOMSService(HealthResponse healthResponse)

        {

            NestedServices ns = new NestedServices();

            ns.serviceName = "BOMSClient";

            string message = string.Empty;



            ServiceStatus status = ServiceStatus.Open;

            Task t = Task.Run(() =>

            {

                status = BOMSClient.Handler.GetStatus();

            });



            if (!t.Wait(5000))

                message = "timeout of 5 seconds";



            if (status == ServiceStatus.Closed)

            {

                ns.httpResponseCode = HttpStatusCode.ServiceUnavailable;

                ns.message = "BOMSClient  is down";

                healthResponse.nestedServices.Add(ns);

            }

            if (!string.IsNullOrEmpty(message))

            {

                ns.httpResponseCode = HttpStatusCode.GatewayTimeout;

                ns.message = "BOMSClient is " + message;

                healthResponse.nestedServices.Add(ns);

            }

        }



        public void CheckSystemTopographyService2(HealthResponse healthResponse)

        {

            NestedServices ns = new NestedServices();

            ns.serviceName = "System Topography Service 2";

            string message = string.Empty;



            ServiceStatus status = ServiceStatus.Open;

            Task t = Task.Run(() =>

            {

                status = STS2Client.Handler.GetStatus();

            });



            if (!t.Wait(5000))

                message = "timeout of 5 seconds";



            if (status == ServiceStatus.Closed)

            {

                ns.httpResponseCode = HttpStatusCode.ServiceUnavailable;

                ns.message = "System Topography Service 2 is down";

                healthResponse.nestedServices.Add(ns);

            }

            if (!string.IsNullOrEmpty(message))

            {

                ns.httpResponseCode = HttpStatusCode.GatewayTimeout;

                ns.message = "System Topography Service 2 is " + message;

                healthResponse.nestedServices.Add(ns);

            }

        }
    }
}
