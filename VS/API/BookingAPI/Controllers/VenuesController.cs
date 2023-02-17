using Microsoft.AspNetCore.Mvc;
using BookingAPI.Models;
using Dapper;
using System.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VenuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<VeluesController>
        [HttpGet("GetAllVenues")]
        public async Task<ActionResult<List<Venues>>> GetAllVenues()
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.QueryAsync<Venues>("select * from venues");
            return Ok(u);

        }

        // GET api/<VeluesController>/5
        [HttpGet("SelectVenueByID/{ID}")]
        public async Task<ActionResult<List<Venues>>> SelectVenueByID(int ID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.QueryAsync<Venues>("select * from venues where VenueID = @venueID", new { venueID = ID});
            return Ok(u);

        }

        // POST api/<VeluesController>

        [HttpPost("CreateVenue")]
        public async Task<ActionResult<List<CreateVenue>>> CreateBooking(CreateVenue Venue)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var c = await con.ExecuteAsync("exec CreateVenue @username,@Name,@Limit,@EmployeeQty,@region,@type,@cvr", Venue);
            return Ok(c);
        }

        // PUT

        [HttpPut("UpdateVenue")]
        public async Task<ActionResult<List<CreateVenue>>> UpdateVenue(UpdateVenue Venue)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.ExecuteAsync("EXEC [UpdateVenue] @username,@Name,@Limit,@EmployeeQty,@region,@type,@cvr,@VenueName", Venue);
            return Ok(u);
        }

        // DELETE api/<VeluesController>/5
        [HttpDelete("{username}/{venuename}")]
        public async Task<ActionResult<List<CreateVenue>>> UpdateVenue(string username, string venuename)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var d = await con.ExecuteAsync("exec [DeleteVenue] @username_ ,@venuename_", new { username_ = username, venuename_ = venuename });
            return Ok(d);
        }
    }
}
