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

        [HttpGet("GetAllBookings/{Usernmae}/{VenueName}")]
        public async Task<ActionResult<List<SelectBookings>>> GetAllBookings(string Usernmae, string VenueName)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var bookings = await con.QueryAsync<SelectBookings>("exec [GetBookings] @username,@VName",
                new { username = Usernmae, VName = VenueName });

            return Ok(bookings);
        }

        [HttpGet("GetBookings/{Usernmae}/{VenueName}/{Date}")]
        public async Task<ActionResult<List<SelectBookings>>> GetBookings(string Usernmae, string VenueName, DateTime Date)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var bookings = await con.QueryAsync<SelectBookings>("exec [GetBookings] @username,@VName,@date",
                new { username = Usernmae, VName = VenueName, date = Date }) ;
            
            return Ok(bookings);
        }

        // GET api/<BookingsController>/5
       
        [HttpGet("GetAllBookingsStatus/{Usernmae}/{VenueName}/{FDate}/{TDate}/{StatusID}")]

        public async Task<ActionResult<List<SelectBookings>>> GetAllBookingsStatus(string Usernmae, string VenueName, string FDate, string TDate, int StatusID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var bookings = await con.QueryAsync<SelectBookings>("exec [GetBookingsStatus] @username,@VName,@Fdate,@Tdate,@statusID",
                new { username = Usernmae, VName = VenueName, Fdate = FDate, Tdate = TDate, statusID = StatusID });

            return Ok(bookings);
        }
     

        // POST api/<BookingsController>
        [HttpPost("CreateBooking")]
        public async Task<ActionResult<List<CreateBookings>>> CreateBooking(CreateBookings booking)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            await con.ExecuteAsync("exec CreateBooking @userName,@venueName,@time,@Pax,@Note", booking);
            return Ok(booking);
        }

        // PUT api/<BookingsController>/5
        [HttpPut("UpdateBoooking")]
        public async Task<ActionResult<List<UpdateBooking>>> UpdateBoooking(UpdateBooking update)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            await con.ExecuteAsync("exec UpdateBooking @username,@BoID,@datetime,@Pax,@note,@TableID", update);
            return Ok(update);
        }

        // PUT api/<BookingsController>/
        [HttpPut("UpdateBoookingStatus")]
        public async Task<ActionResult<string>> UpdateBoookingStatus(string Uname,int bookingID, int statusID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            await con.ExecuteAsync("exec UpdateBookingStatus @username, @BoID,@Status", new { username = Uname, BoID = bookingID, Status= statusID });
            return Ok("Booking has been updated"); 
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("DeleteBooking")]
        public async Task<ActionResult<string>> DeleteBooking(string Uname,int ID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            await con.ExecuteAsync("exec DeleteBooking @username,@BoID", new { username = Uname, BoID = ID });
            return Ok("Booking has been deleted");
        }
    }
}
