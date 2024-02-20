using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace WebApp_E
{
    public static class GlobleVeriable
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobleVeriable()
        {
            WebApiClient.BaseAddress = new Uri("https://api2.bijli-bachao-dashboard.pk/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }

    }
}