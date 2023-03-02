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

        public static async Task<Venues> GetVenueByName(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(api + $"Venues/GetVenueByName/{name}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Venues>(content);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"Failed to get venue by name: {response.StatusCode}");
                }
            }
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

        public static async Task<List<BookingsData>> GetBookingsByVenue(string username, string venuename, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(api + $"Bookings/GetBookingsByVname?username={username}&venuename={venuename}&password={password}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var bookings = JsonConvert.DeserializeObject<List<BookingsData>>(jsonString);
                    return bookings;
                }
                else
                {
                    return null;
                }
            }
        }


        public static async Task<List<BookingsData>> GetBookingByID(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + $"Bookings/GetBookingsByID?ID={id}"))
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

       

        public static async Task<List<BookingsData>> GetBookingsByDate(string username,string venuename, string date)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(api + $"Bookings/GetBookingsByDate?username={username}&venueName={venuename}&date={date}"))
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

        internal static Task GetBookingsByID(string? bookingId)
        {
            throw new NotImplementedException();
        }


        //get venue items 

        public static async Task<List<VenueItems>> GetVenueItemsByVenueName(string venueName, string username)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(api + $"VenueItems/GetVenueItemsByVenueName/{venueName}/{username}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var venueItems = JsonConvert.DeserializeObject<List<VenueItems>>(jsonString);
                    return venueItems;
                }
                else
                {
                    return null;
                }
            }
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

        // venueItem 

        public static async Task<HttpResponseMessage> CreateVenueItem(CreateVenueItem venueItem)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(venueItem), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api + "VenueItems/CreateVenueItem", content);
                return response;
            }
        }


        // Put

        //Venue 

        public static async Task<string> UpdateVenue(UpdateVenue venue)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(venue), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(api + "Venues/UpdateVenue", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task<HttpResponseMessage> EditUser(int UserID, UserData userData)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(userData), Encoding.UTF8, "application/json");
                return await client.PutAsync(api + "$User/EditUser /" + UserID, content);
            }
        }

        // booking
        public static async Task<string> UpdateBooking(UpdateBooking booking)
        {
            using (HttpClient client = new HttpClient())
            {
                var bookingJson = JsonConvert.SerializeObject(booking);
                var content = new StringContent(bookingJson, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(api + "Bookings/UpdateBooking", content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();

                }

            }
        }



        public static async Task<HttpResponseMessage> UpdateBookingStatus(int bookingId, string statusId, string username)
        {
            using (HttpClient client = new HttpClient())
            {
                var bookingStatus = new UpdateStatus { status = statusId, username = username };

                var content = new StringContent(JsonConvert.SerializeObject(bookingStatus), Encoding.UTF8, "application/json");

                return await client.PutAsync(api + $"Bookings/UpdateBookingStatus/{bookingId}", content);
            }
        }

        // venueItem 

        public static async Task<HttpResponseMessage> UpdateVenueItem(UpdateVenueItem venueItem)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(venueItem), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(api + "VenueItems/UpdateVenueItem", content);
                return response;
            }
        }


        // DELETE

        // DELETE booking
        public static async Task<HttpResponseMessage> DeleteBooking(int id, string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.DeleteAsync(api + $"Bookings/{id}?username={username}&password={password}");

                return response;
            }
        }
    }
}
