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

        // GET User
        public static async Task<int> VerifyUser(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + "User/LogInCheck?username=" + username + "&password=" + password))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        string result = await res.Content.ReadAsStringAsync();
                        if (result == "Login successful. You are a venue owner.")
                        {
                            return 1;
                        }
                        else if (result == "Login successful. You are not a venue owner.")
                        {
                            return 0;
                        }
                    }
                }
            }
            return 2;
        }

        // get venue

        public static async Task<List<Venues>> GetAllVenues()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + "Venues/GetAllVenues"))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        var content = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Venues>>(content);
                    }
                }
            }
            return null;
        }

        // get all the venuesFor the admin 
        public static async Task<List<Venues>> GetAllVenuesForOwner(string username)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + "Venues/GetVenuesByUsername/"+username))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        var content = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Venues>>(content);
                    }
                }
            }
            return null;
        }

        // get all bookings

        public static async Task<List<BookingsData>> GetBookingsByUsername(string username)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + $"Bookings/GetBookingsByUsername?username={username}"))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        var content = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<BookingsData>>(content);
                    }
                }
            }
            return null;
        }

        public static async Task<Users> GetUser(string username)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + $"User/GetUser/{username}"))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        var content = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Users>(content);
                    }
                }
            }
            return null;
        }

        // POST user


        public static async Task<HttpResponseMessage> CreateUser(CreateUser user)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                return await client.PostAsync(api + "User/CreateUser", content);
            }
        }

        // Post Venue

        public static async Task<HttpResponseMessage> CreateVenue(CreateVenues venue)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(venue), Encoding.UTF8, "application/json");
                return await client.PostAsync(api + "Venues/CreateVenue", content);
            }
        }

        // booking

        public static async Task<HttpResponseMessage> CreateBooking(CreateBookings booking)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                return await client.PostAsync(api + "Bookings/CreateBooking", content);
            }
        }

        // Put

        public static async Task<HttpResponseMessage> EditUser(int UserID, UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
                return await client.PutAsync(api + "$User/EditUser /" + UserID, content);
            }
        }



    }
}
