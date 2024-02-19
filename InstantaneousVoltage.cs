using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using WebApp_E.Models;

namespace WebApp_E.ApiCall
{
    public static class InstantaneousVoltage
    {
  
    public static void VoltageApi(String id)
        {
           
                try
                {
                    var url = "https://api2.bijli-bachao-dashboard.pk/DailyAverageVoltage_New";
                    var requestData = new
                    {
                        id = id,
                        type = "L123",
                      
                    };
                    // Serialize the object to JSON
                    var json = JsonConvert.SerializeObject(requestData);
                    using (var wb = new WebClient())
                    {
                        // Set the content type header to application/json
                        wb.Headers[HttpRequestHeader.ContentType] = "application/json";
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
    public static void LiveVoltageApi(String id)
        {
   
            try
                {
                    var url = "https://api2.bijli-bachao-dashboard.pk/Phase123";
                    var requestData = new
                    {
                        reqtype = "InstL123",
                        msn = id,
                      
                    };
                    // Serialize the object to JSON
                    var json = JsonConvert.SerializeObject(requestData);
                    using (var wb = new WebClient())
                    {
                        // Set the content type header to application/json
                        wb.Headers[HttpRequestHeader.ContentType] = "application/json";
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

        public static void CurrentApi(String id)
        {

            try
            {
                var url = "https://api2.bijli-bachao-dashboard.pk/DailyAverageCurrent_New";
                var requestData = new
                {
                    id = id,
                    type = "L123",

                };
                // Serialize the object to JSON
                var json = JsonConvert.SerializeObject(requestData);
                using (var wb = new WebClient())
                {
                    // Set the content type header to application/json
                    wb.Headers[HttpRequestHeader.ContentType] = "application/json";
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
        public class unitsByDate
        {
            public string Id { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
        }
 public static void UnitsByDate(unitsByDate UnitsByDate)
        {
 
            try
            {
                var url = "https://api2.bijli-bachao-dashboard.pk/UnitsbyDatesT2";
                var requestData = new
                {
                    msn = UnitsByDate.Id,
                    start_date = UnitsByDate.startDate,
                    end_date = UnitsByDate.endDate
                };
                // Serialize the object to JSON
                var json = JsonConvert.SerializeObject(requestData);
                using (var wb = new WebClient())
                {
                    // Set the content type header to application/json
                    wb.Headers[HttpRequestHeader.ContentType] = "application/json";
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