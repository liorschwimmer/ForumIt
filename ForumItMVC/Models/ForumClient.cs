using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace ForumItMVC.Models
{
    public class ForumClient
    {
        private string BaseUrl = "http://localhost/ForumItWebApi/api/forums";

        public IEnumerable<Forum> GetAllForums()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    HttpResponseMessage response = client.GetAsync("Forums").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<IEnumerable<Forum>>().Result;

                    }

                    return null;
                }
            }
            catch(Exception ex)
            {

                return null;
            }
        }
    }
}