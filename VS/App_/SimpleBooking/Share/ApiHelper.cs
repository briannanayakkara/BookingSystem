using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBooking.Share
{
    public static class ApiHelper
    {
        private static readonly string api = "https://localhost:7022/api/";

        // GET
        public static async Task<bool> VerifyUser(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + "User/LogInCheck?username=" + username + "&password=" + password))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        // Log the user in
                        
                        return true;
                    }
                }
            }
            return false;
        }





        public static string Pretty(string jsoneStr)
        {
            JToken jToken = JToken.Parse(jsoneStr);
            return jToken.ToString(Newtonsoft.Json.Formatting.Indented);
        }

        // POST


        public static async Task<HttpResponseMessage> CreateUser(CreateUser user)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                return await client.PostAsync(api + "User/CreateUser", content);
            }
        }



    }
}
