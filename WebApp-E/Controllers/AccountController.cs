using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_E.Models;

namespace WebApp_E.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            

            return View();
        }





        static async Task CallApi()
        {
            try
            {
                var requestData1 = new
                {
                    reqtype = "login",
                    user_name = "DHA8",
                    pass_word = "DHA8"
                };
                LoginViewModel model = new LoginViewModel();

                model.reqtype = requestData1.reqtype;
                model.user_name = requestData1.user_name;
                model.pass_word = requestData1.pass_word;
                var abc = GlobleVeriable.WebApiClient.PostAsJsonAsync("login", model).Result;
                var abd = abc.Content.ReadAsStringAsync().Result;
                var responseData = JsonConvert.DeserializeObject<UserInfo>(abd);


                var url = "https://api2.bijli-bachao-dashboard.pk/login";
                var requestData = new
                {
                    reqtype = "login",
                    user_name = "DHA8",
                    pass_word = "DHA8"
                };
                // Serialize the object to JSON
                var json = JsonConvert.SerializeObject(requestData);
                using (var wb = new WebClient())
                {
                    // Set the content type header to application/json
                    var absc = wb.Headers[HttpRequestHeader.ContentType] = "application/json";
                    // Send the POST request and get the response
                    var response = wb.UploadString(url, "POST", json);
                    // Handle the response as needed
                    Console.WriteLine(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
            }
        }
    }
}