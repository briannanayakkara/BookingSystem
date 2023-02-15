using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookingAPI.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BookingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<BookingsController>/ID
        [HttpGet("GetAllBookings")]
        public string GetAllBookings(string Usernmae, string VenueName)
        {
            string q = "exec [GetBookings] "+ Usernmae+","+ VenueName;

            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
            Response r = new Response();
            using (SqlConnection cnn = new SqlConnection(con))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(q, cnn))
                {
                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                r.StatusCode = 100;
                r.Message = "No Data found";
                return JsonConvert.SerializeObject(r);

            }
        }

        // GET api/<BookingsController>/5
        [HttpGet("GetAllBookingsOnDate")]
        public string GetAllBookingsOnDate(string Usernmae, string VenueName,string date)
        {
            string q = "exec [GetBookings] '" + Usernmae + "','" + VenueName+"','"+ date+"'";

            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
            Response r = new Response();
            using (SqlConnection cnn = new SqlConnection(con))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(q, cnn))
                {
                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                r.StatusCode = 100;
                r.Message = "No Data found";
                return JsonConvert.SerializeObject(r);

            }
        }

        [HttpGet("GetAllBookingsOnDateAndStatus")]
        public string GetAllBookingsOnDateAndStatus(string Usernmae, string VenueName, string date,int StatusID)
        {
            string q = "exec [GetBookings] '" + Usernmae + "','" + VenueName + "','" + date + "','"+ StatusID+"'";

            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
            Response r = new Response();
            using (SqlConnection cnn = new SqlConnection(con))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(q, cnn))
                {
                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                r.StatusCode = 100;
                r.Message = "No Data found";
                return JsonConvert.SerializeObject(r);

            }
        }

        // POST api/<BookingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
