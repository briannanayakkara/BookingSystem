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

        [HttpGet("GetVenueByName/{name}")]
        public async Task<ActionResult<Venues>> GetVenueByName(string name)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT * FROM Venues WHERE Name = @Name", new { Name = name });
            if (venue == null)
            {
                return NotFound();
            }
            return Ok(venue);
        }

        // GET: api/<VeluesController>
        [HttpGet("GetAllVenues")]
        public async Task<ActionResult<List<Venues>>> GetAllVenues()
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var venues = await con.QueryAsync<Venues>("SELECT * FROM venues");
            return Ok(venues);
        }

        // GET api/<VeluesController>/5
        [HttpGet("GetVenuesByUsername/{username}")]
        public async Task<ActionResult<List<Venues>>> GetVenuesByUsername(string username)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var venues = await con.QueryAsync<Venues>(@"select v.* from venues v
                                                join VenueOwners vo on v.VenueID = vo.VenueID
                                                join Users u on u.UserID = vo.UserID
                                                where username = @username", new { username });
            return Ok(venues);
        }

        // POST api/<VeluesController>

        [HttpPost("CreateVenue")]
        public async Task<ActionResult<List<CreateVenue>>> CreateVenue(CreateVenue Venue)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var query = @"DECLARE @UserID int = (select UserID from Users where username = @username)

            DECLARE @VenueID int= 0
            DECLARE @AdminLvl int = (select AdminLevel from Users where username = @username)

            IF NOT EXISTS (select * from Venues v join VenueOwners vo on vo.VenueID = v.VenueID where Name = @Name)
                BEGIN
                    IF (select @AdminLvl) = 1
                        BEGIN
                            INSERT INTO Venues(Name,Limit,EmployeeQty,Region,Type,CVR)
                            select @Name,@Limit,@EmployeeQty,@region,@type,@cvr

                            set @VenueID = (select VenueID from Venues where Name = @Name)

                            INSERT INTO VenueOwners(UserID,VenueID)
                            select @UserID,@VenueID
                        END
                END";

            var c = await con.ExecuteAsync(query, Venue);
            return Ok(c);
        }

        // PUT

        [HttpPut("UpdateVenue")]
        public async Task<ActionResult<Venues>> UpdateVenue(UpdateVenue Venue)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            // Check if the venue exists
            var venueId = await con.ExecuteScalarAsync<int?>(
                "SELECT VenueID FROM Venues WHERE Name = @VenueName", new { Venue.VenueName });
            if (!venueId.HasValue)
            {
                return BadRequest("Venue does not exist");
            }

            // Check if the user is an owner of the venue
            var userId = await con.ExecuteScalarAsync<int?>(
                "SELECT UserID FROM Users WHERE Username = @Username", new { Venue.username });
            if (!userId.HasValue)
            {
                return BadRequest("User does not exist");
            }
            var isOwner = await con.ExecuteScalarAsync<bool>(
                "SELECT COUNT(*) FROM VenueOwners WHERE VenueID = @VenueID AND UserID = @UserID",
                new { VenueID = venueId.Value, UserID = userId.Value });
            if (!isOwner)
            {
                return BadRequest("User is not an owner of the venue");
            }

            // Check if the new name is already taken
            var newNameTaken = await con.ExecuteScalarAsync<bool>(
                "SELECT COUNT(*) FROM Venues WHERE Name = @Name AND VenueID != @VenueID",
                new { Venue.Name, VenueID = venueId.Value });
            if (newNameTaken)
            {
                return BadRequest("Venue name is already taken");
            }

            // Update the venue
            var result = await con.ExecuteAsync(
                "UPDATE Venues SET Name = @Name, Limit = @Limit, EmployeeQty = @EmployeeQty, Type = @Type, CVR = @CVR, Region = @Region WHERE VenueID = @VenueID",
                new { Venue.Name, Venue.Limit, Venue.EmployeeQty, Venue.type, Venue.cvr, Venue.region, VenueID = venueId.Value });
            if (result == 0)
            {
                return BadRequest("Failed to update venue");
            }
            return Ok();
        }


        // DELETE api/<VeluesController>/5
        [HttpDelete("DeleteVenue/{username}/{venueName}")]
        public async Task<ActionResult<Venues>> DeleteVenue(string username, string venueName)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var venueId = await con.QuerySingleOrDefaultAsync<int>(
                "SELECT VenueID FROM Venues WHERE Name = @venueName", new { venueName });
            if (venueId == 0)
            {
                return NotFound("Venue not found");
            }
            var userId = await con.QuerySingleOrDefaultAsync<int>(
                "SELECT UserID FROM Users WHERE username = @username", new { username });
            if (userId == 0)
            {
                return NotFound("User not found");
            }
            var ownerId = await con.QuerySingleOrDefaultAsync<int>(
                "SELECT UserID FROM VenueOwners WHERE VenueID = @venueId", new { venueId });
            if (ownerId != userId)
            {
                return Unauthorized("You are not the owner of this venue");
            }
            var futureBookings = await con.QueryAsync<Bookings>(
                "SELECT * FROM Bookings WHERE VenueID = @venueId AND Time > GETDATE()", new { venueId });
            if (futureBookings.Any())
            {
                return BadRequest("There are future bookings for this venue");
            }
            await con.ExecuteAsync(
                "DELETE FROM VenueItems WHERE VenueID = @venueId", new { venueId });
            await con.ExecuteAsync(
                "DELETE FROM VenueOwners WHERE VenueID = @venueId", new { venueId });
            await con.ExecuteAsync(
                "DELETE FROM Venues WHERE VenueID = @venueId", new { venueId });
            return NoContent();
        }


    }
}
