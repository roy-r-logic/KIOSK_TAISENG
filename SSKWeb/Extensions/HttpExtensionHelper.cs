using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSKWeb.Extensions
{
    public static class HttpExtensionHelper
    {
        public static async Task<Dictionary<string, List<string>>> ReadErrorAsync(this HttpContent content)
        {
            var json = content.ReadAsStringAsync().Result;

            var data = (JObject)JsonConvert.DeserializeObject(json);

            var errors = data.Properties().ToList().Where(x => x.Name == "errors");
            var dic = new Dictionary<string, List<string>>();
            if (!errors.Any())
            {
                await Task.CompletedTask;
                return dic;
            }

            if (!errors.Children().Any())
            {
                await Task.CompletedTask;

                return dic;
            }

            var items = errors.Children().Children().ToList();

            if (!items.Any())
            {
                await Task.CompletedTask;

                return dic;
            }

            foreach (var i in items)
            {
                var jp = (JProperty)i;

                var name = jp.Name;

                foreach (var v in jp.Value)
                {
                    if (dic.ContainsKey(name))
                    {
                        dic[name].Add(v.Value<string>());
                    }
                    else
                    {
                        dic.Add(name, new List<string> { v.Value<string>() });
                    }
                }

            }
            await Task.CompletedTask;

            return dic;
        }
    }
}
