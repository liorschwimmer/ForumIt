using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ForumItMVC.Models
{
    public class ForumClient
    {
        private string BaseUrl = "http://localhost/ForumItWebApi/api/forums/"; 

        //public IEnumerable<Forum> GetAllForums()
        //{
        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        client.BaseAddress = new Uri(BaseUrl);

        //        HttpResponseMessage response = client.GetAsync("Forum").Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return response.Content.ReadasAsyc
        //        }

        //        return null;
        //    }
        //    catch 
        //    {

        //        return null;
        //    }
        //}
    }
}