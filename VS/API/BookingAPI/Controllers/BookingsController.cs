using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookingAPI.Models;
using Newtonsoft.Json;
using Dapper;
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


        [HttpGet("GetBookings/{Usernmae}/{VenueName}/{Date}")]
        public async Task<ActionResult<List<Bookings>>> GetBookings(string Usernmae, string VenueName, DateTime Date)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var bookings = await con.QueryAsync<Bookings>("exec [GetBookings] @username,@VName,@date",
                new { username = Usernmae, VName = VenueName, date = Date }) ;
            
            return Ok(bookings);
        }

        // GET api/<BookingsController>/5
       
        [HttpGet("GetAllBookingsStatus/{Usernmae}/{VenueName}/{FDate}/{TDate}/{StatusID}")]

        public async Task<ActionResult<List<Bookings>>> GetAllBookingsStatus(string Usernmae, string VenueName, string FDate, string TDate, int StatusID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var bookings = await con.QueryAsync<Bookings>("exec [GetBookingsStatus] @username,@VName,@Fdate,@Tdate,@statusID",
                new { username = Usernmae, VName = VenueName, Fdate = FDate, Tdate = TDate, statusID = StatusID });

            return Ok(bookings);
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
