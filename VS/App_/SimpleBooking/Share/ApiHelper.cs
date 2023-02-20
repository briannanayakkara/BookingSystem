using Newtonsoft.Json.Linq;
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
        public static async Task<string> VerifyU(string usernama, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + "User/LogInCheck?username=" + usernama + "&password=" + password))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }

            }
            return string.Empty;
        }

        public static string Pretty(string jsoneStr)
        {
            JToken jToken = JToken.Parse(jsoneStr);
            return jToken.ToString(Newtonsoft.Json.Formatting.Indented);
        }

        // POST

        public static async Task<string> CreateUserPost(string Fname, string Sname, string usernama, string email, string phone, string region, string bday, string password)
        {


            //password = BCrypt.Net.BCrypt.HashPassword(password);

            var inputDate = new Dictionary<string,string>
            {
                    {"adminLvl", "0"},
                    {"firstname",Fname},
                    {"lastname", Sname},
                    {"username", usernama},
                    {"email", email},
                    {"phone", phone},
                    {"region", region},
                    {"bday", bday},
                    {"pass", password}
            };
            var input = new FormUrlEncodedContent(inputDate);
            using (HttpClient client = new HttpClient())
            {
                //https://localhost:7022/api/User/CreateUser?AdminLevel=0&Fname=ss&SName=ss&UserName=ss&Email=ss&Phone=111&Region=ss&Birthday=1999-05-05&pass=pass
                using (HttpResponseMessage res = await client.PostAsync(api + "User/CreateUser", input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }

            }
            return string.Empty;
        }


    }
}
