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
    public class CollectQueueListApiServices
    {
        private HttpClient _client;

        public CollectQueueListApiServices()
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

        

        public async Task<string> PostCollectQueueListJobAsync(PostCollectQueueListViewModel vm)
        {

            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "LenovoCollectQueueList/CreateCollectQueueList"));

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
                            //var api = new PostRegisterCustomerInfoResultModel();
                            //var error = await response.Content.ReadErrorAsync();
                            //if (error.Count > 0)
                            //{
                            //    api.Errors = error;
                            //    return api;
                            //}
                        }
                    }
                //    var responseContent = await response.Content.ReadAsAsync<PostRegisterCustomerInfoResultModel>();

                    return "ok";
                }
            }

        }

        public async Task<List<GetCollectQueueListViewModel>> GetCollectQueueListAsync()
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "LenovoCollectQueueList/GetCollectQueueLists"));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);

                using (HttpResponseMessage response = _client.SendAsync(request).Result)
                {


                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            var api = new GetCollectQueueListViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                                //return api;
                            }
                        }
                    }
                    var responseContent = await response.Content.ReadAsAsync<List<GetCollectQueueListViewModel>>();
                    return responseContent;
                }
            }
        }

        public async Task<GetCollectQueueListViewModel> GetCollectQueueListStatusProcessingAsync()
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "LenovoCollectQueueList/GetCollectQueueListStatusProcessing"));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);

                using (HttpResponseMessage response = _client.SendAsync(request).Result)
                {


                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            var api = new GetCollectQueueListViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                                //return api;
                            }
                        }
                    }
                    var responseContent = await response.Content.ReadAsAsync<GetCollectQueueListViewModel>();
                    return responseContent;
                }
            }
        }

        public async Task<string> UpdateCollectQueueListStatusToWaitingAsync()
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "LenovoCollectQueueList/UpdateCollectQueueListToWaiting"));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);
                using (HttpResponseMessage response = await _client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {

                        }
                        else if ((int)response.StatusCode == 500)
                        {
                            //var api = new GetCollectQueueListViewModel();
                            //var error = response.Content.ReadErrorAsync().Result;
                            //if (error.Count > 0)
                            //{
                            //    //  api.Errors = error;
                            //    return api;
                            //}
                        }
                    }

                    //var responseContent = await response.Content.ReadAsAsync<GetCollectQueueListViewModel>();
                    return "ok";
                }
            }
        }

        public async Task<GetCollectQueueListViewModel> UpdateCollectQueueListToProcessingAsync()
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "LenovoCollectQueueList/UpdateCollectQueueListToProcessing"));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);
                using (HttpResponseMessage response = await _client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            var api = new GetCollectQueueListViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                              //  api.Errors = error;
                                return api;
                            }
                        }
                        else if ((int)response.StatusCode == 500)
                        {
                            var api = new GetCollectQueueListViewModel();
                            var error = response.Content.ReadErrorAsync().Result;
                            if (error.Count > 0)
                            {
                              //  api.Errors = error;
                                return api;
                            }
                        }
                    }

                    var responseContent = await response.Content.ReadAsAsync<GetCollectQueueListViewModel>();
                    return responseContent;
                }
            }
        }

        public async Task<string> UpdateCollectQueueListStatusToCompletedAsync()
        {
            var uri = new Uri(string.Format(AppConstant.API_Lenovo_Uri, "LenovoCollectQueueList/UpdateCollectQueueListStatusToCompleted"));

            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppConstant.API_Lenovo_Token);
                using (HttpResponseMessage response = await _client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            //var api = new GetCollectQueueListViewModel();
                            //var error = response.Content.ReadErrorAsync().Result;
                            //if (error.Count > 0)
                            //{
                            //    //  api.Errors = error;
                            //    return api;
                            //}
                        }
                        else if ((int)response.StatusCode == 500)
                        {
                            //var api = new GetCollectQueueListViewModel();
                            //var error = response.Content.ReadErrorAsync().Result;
                            //if (error.Count > 0)
                            //{
                            //    //  api.Errors = error;
                            //    return api;
                            //}
                        }
                    }

                    //var responseContent = await response.Content.ReadAsAsync<GetCollectQueueListViewModel>();
                    return "ok";
                }
            }
        }


       
    }

}

