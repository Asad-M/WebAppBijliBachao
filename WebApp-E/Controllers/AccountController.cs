using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp_E.Models;

namespace WebApp_E.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();


            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var response = GlobleVeriable.WebApiClient.PostAsJsonAsync("login", model).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = response.Content.ReadAsStringAsync().Result;
                        var RecivedResponseData = JsonConvert.DeserializeObject<UserInfo>(responseData);


                        // Set authentication cookie
                        //FormsAuthentication.SetAuthCookie(RecivedResponseData.full_name, false);

                        // Create authentication ticket
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                            1, // Version
                            RecivedResponseData.msn, // Username to persist in ticket
                            DateTime.Now, // Issue date
                            DateTime.Now.AddMinutes(30), // Expiration date
                            false, // Persistent cookie
                            "optionalUserData" // User data (optional)
                        );

                        // Encrypt the ticket and add it to a cookie
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        Response.Cookies.Add(authCookie);



                        if (User.Identity.IsAuthenticated)
                        { }

                        return RedirectToAction("About","Home");
                    }
                }
                

            }
            catch { }
            return RedirectToAction("Login", "Account");
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