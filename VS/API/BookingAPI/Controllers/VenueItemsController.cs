using Microsoft.AspNetCore.Mvc;
using BookingAPI.Models;
using Dapper;
using System.Data.SqlClient;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VenueItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetVenueItemsByVenueName/{venueName}/{username}")]
        public async Task<ActionResult<IEnumerable<VenueItems>>> GetVenueItemsByVenueName(string venueName, string username)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var result = await con.QueryAsync<VenueItems>(
                "SELECT * FROM VenueItems WHERE VenueID = (SELECT VenueID FROM Venues WHERE Name = @venueName)" +
                " AND (SELECT UserID FROM Users WHERE username = @username) = (SELECT UserID FROM VenueOwners WHERE VenueID = (SELECT VenueID FROM Venues WHERE Name = @venueName))",
                new { venueName, username });
            if (!result.Any())
            {
                return NotFound("Venue Items not found");
            }
            return Ok(result);
        }


        // POST api/<VenueItemsController>
        [HttpPost("CreateVenueItem")]
        public async Task<ActionResult<VenueItems>> CreateVenueItem(CreateVenueItem venueItem)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT VenueID FROM Venues WHERE Name = @VenueName", new { VenueName = venueItem.VenueName });
            if (venue == null)
            {
                return BadRequest("Venue does not exist");
            }

            var venueOwner = await con.QuerySingleOrDefaultAsync<VenueOwners>(
                "SELECT UserID FROM VenueOwners WHERE VenueID = @VenueID AND UserID = (SELECT UserID FROM Users WHERE username = @username)",
                new { VenueID = venue.VenueID, Username = venueItem.Username });
            if (venueOwner == null)
            {
                return BadRequest("You are not an owner of this venue");
            }

            var result = await con.ExecuteAsync(
                "INSERT INTO VenueItems (VenueID, TableNr, Pax, TableType) VALUES (@VenueID, @TableNr, @Pax, @TableType)",
                new { VenueID = venue.VenueID, TableNr = venueItem.TableNr, Pax = venueItem.Pax, TableType = venueItem.TableType });
            if (result == 0)
            {
                return BadRequest("Failed to create venue item");
            }

            return Ok();
        }


        // PUT api/<VenueItemsController>/5
        [HttpPut("UpdateVenueItem")]
        public async Task<ActionResult<VenueItems>> UpdateVenueItem(UpdateVenueItem venueItem)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT VenueID FROM Venues WHERE Name = @VenueName", new { VenueName = venueItem.VenueName });
            if (venue == null)
            {
                return BadRequest("Venue does not exist");
            }

            var venueOwner = await con.QuerySingleOrDefaultAsync<VenueOwners>(
                "SELECT UserID FROM VenueOwners WHERE VenueID = @VenueID AND UserID = (SELECT UserID FROM Users WHERE username = @username)",
                new { VenueID = venue.VenueID, Username = venueItem.Username });
            if (venueOwner == null)
            {
                return BadRequest("You are not an owner of this venue");
            }

            var result = await con.ExecuteAsync(
                "UPDATE VenueItems SET TableNr = @TableNr, Pax = @Pax, TableType = @TableType WHERE TableID = @TableID",
                new { TableID = venueItem.TableID, TableNr = venueItem.TableNr, Pax = venueItem.Pax, TableType = venueItem.TableType });
            if (result == 0)
            {
                return BadRequest("Failed to update venue item");
            }

            return Ok();
        }



        // DELETE api/<VenueItemsController>/5
        [HttpDelete("DeleteVenueItem")]
        public async Task<ActionResult<VenueItems>> DeleteVenueItem(int tableID, string username)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var venueItem = await con.QuerySingleOrDefaultAsync<VenueItems>(
                "SELECT VenueID FROM VenueItems WHERE TableID = @TableID", new { TableID = tableID });
            if (venueItem == null)
            {
                return BadRequest("Venue item does not exist");
            }

            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT VenueID FROM Venues WHERE VenueID = @VenueID", new { VenueID = venueItem.VenueID });
            if (venue == null)
            {
                return BadRequest("Venue does not exist");
            }

            var venueOwner = await con.QuerySingleOrDefaultAsync<VenueOwners>(
                "SELECT UserID FROM VenueOwners WHERE VenueID = @VenueID AND UserID = (SELECT UserID FROM Users WHERE username = @username)",
                new { VenueID = venue.VenueID, Username = username });
            if (venueOwner == null)
            {
                return BadRequest("You are not an owner of this venue");
            }

            var bookings = await con.QueryAsync<Bookings>(
                "SELECT * FROM Bookings WHERE TableID = @TableID AND Time >= GETDATE()", new { TableID = tableID });
            if (bookings.Any())
            {
                return BadRequest("Cannot delete venue item as there are future bookings for this table");
            }

            var result = await con.ExecuteAsync(
                "DELETE FROM VenueItems WHERE TableID = @TableID", new { TableID = tableID });
            if (result == 0)
            {
                return BadRequest("Failed to delete venue item");
            }

            return Ok();
        }
    }
}
