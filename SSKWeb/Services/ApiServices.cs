using Newtonsoft.Json;
using SSKWeb.Extensions;
using SSKWeb.Helpers;
using SSKWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SSKWeb.Services
{
    public class ApiServices
    {
        private HttpClient _client;

        public ApiServices()
        {
            ServicePointManager.ServerCertificateValidationCallback =
               delegate (
                   object s,
                   X509Certificate certificate,
                   X509Chain chain,
                   SslPolicyErrors sslPolicyErrors
               )
               {
                   return true;
               };

           // _client = new HttpClient();
          //  _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            _client = new HttpClient(httpClientHandler);


            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ResultWarrantyViewModel> GetRepairInfoBySerialNoAsync(string serialNo)
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, string.Format("Lenovo/GetWarranty?Serial={0}", serialNo)));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
              //  request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);
                using (HttpResponseMessage response = await _client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            var api = new ResultWarrantyViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                                api.Errors = error;
                                return api;
                            }
                        }
                        else if ((int)response.StatusCode == 500)
                        {
                            var api = new ResultWarrantyViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                                api.Errors = error;
                                return api;
                            }
                        }
                    }

                    var responseContent = await response.Content.ReadAsAsync<ResultWarrantyViewModel>();
                    return responseContent;
                }
            }
        }


        public async Task<List<ProblemDescriptionModel>> GetProblemDescriptionAsync()
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "CCI/GetProblemDescription"));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                 request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);
                // _client.he.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              //  _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);
                using (HttpResponseMessage response = _client.SendAsync(request).Result)
                {


                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            var api = new PreDropGoRegistrationViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                                //return api;
                            }
                        }
                    }
                    var responseContent = await response.Content.ReadAsAsync<List<ProblemDescriptionModel>>();
                    return responseContent;
                }
            }
        }

        public async Task<PostRegisterCustomerInfoResultModel> PostJobAsync(PostRegisterCustomerInfoModel vm)
        {

            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "CCI/CreateJob"));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                var json = JsonConvert.SerializeObject(vm);

                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);

                using (HttpResponseMessage response = await _client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            var api = new PostRegisterCustomerInfoResultModel();
                            var error = await response.Content.ReadErrorAsync();
                            if (error.Count > 0)
                            {
                                api.Errors = error;
                                return api;
                            }
                        }
                    }
                    var responseContent = await response.Content.ReadAsAsync<PostRegisterCustomerInfoResultModel>();

                    return responseContent;
                }
            }

        }

        public async Task<ResultJobViewModel> GetJobInfoAsync(string jobTag)
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, string.Format("CCI/IsJobtagValid?JobTag={0}", jobTag)));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);
                using (HttpResponseMessage response = await _client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            var api = new ResultJobViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                                api.Errors = error;
                                return api;
                            }
                        }
                        else if ((int)response.StatusCode == 500)
                        {
                            var api = new ResultJobViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                                api.Errors = error;
                                return api;
                            }
                        }
                    }

                    var responseContent = await response.Content.ReadAsAsync<ResultJobViewModel>();
                    return responseContent;
                }
            }
        }
    }

}

