using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SSKApp.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<Tout> ReadAsAsync<Tout>(this HttpContent content)
        {
            return JsonConvert.DeserializeObject<Tout>(await content.ReadAsStringAsync());
        }

    }
}
