using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HeaderDisplay.Models
{
    public class Helpers
    {
        public async static Task<HeadersViewModel> GetHeaders(PostViewModel formData)
        {
            //TODO: Ensure format of url
            if(!formData.Url.StartsWith("www") || !formData.Url.StartsWith("http"))
            {
                formData.Url = $"http://{formData.Url}";
            }

            var client = new HttpClient();
            var responseMessage = await client.GetAsync(formData.Url);

            return ProcessHeaders(responseMessage, formData);
        }

        private static HeadersViewModel ProcessHeaders(HttpResponseMessage response, PostViewModel formData)
        {
            var model = new HeadersViewModel();

            var headers = response.Headers.Concat(response.Content.Headers);

            var toExclude = new List<string>();
            if (!string.IsNullOrEmpty(formData.ExcludeHeaders))
            {
                toExclude = formData.ExcludeHeaders.Split(',').ToList();
            }

            foreach (var h in headers)
            {
                if (toExclude.FirstOrDefault(x => x.Equals(h.Key)) == null)
                    model.Headers.Add(h.Key, h.Value.FirstOrDefault());
            }


            //foreach (var h in headers)
            //{
            //    if (toExclude.Any())
            //    {
            //        foreach (var excludeHeader in toExclude)
            //        {
            //            if (toExclude.Contains(h.Key))
            //            {
            //                //Do not add this header because h.key matches excludeHeader
            //            }
            //            else
            //            {
            //                //Add this header
            //                if (!model.Headers.ContainsKey(h.Key))
            //                    model.Headers.Add(h.Key, h.Value.FirstOrDefault());
            //            }
            //        }
            //    }
            //    //toExclude doenst contain any elements, no need to inspect and compare. Add all.
            //    else
            //    {
            //        if (!model.Headers.ContainsKey(h.Key))
            //            model.Headers.Add(h.Key, h.Value.FirstOrDefault());
            //    }
            //}


            return model;
        }
    }
}