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

        [HttpGet("GetBookingsByID")]
        public async Task<ActionResult<IEnumerable<BookingsByDate>>> GetBookingsByID(string ID )
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var Booking = await con.QuerySingleOrDefaultAsync<Users>(
                "SELECT * FROM bookings WHERE ID = @BID", new { BID = ID });
            if (Booking == null)
            {
                return BadRequest("User does not exist");
            }

            var bookings = await con.QueryAsync<BookingsByDate>(@"
        SELECT 
            b.ID, 
            u.Firstname + ' ' + u.Lastname AS fullname, 
            u.Email, 
            u.Phone, 
            b.Pax AS pax, 
            vi.Pax AS tableSize, 
            vi.TableNr, 
            b.Note,
            b.Time, 
            v.name AS Venue, 
            uvi.Firstname + ' ' + uvi.Lastname AS venueOwner, 
            s.Status 
        FROM 
            bookings b 
            JOIN users u ON u.UserID = b.UserID 
            JOIN Venues v ON b.VenueID = v.VenueID
            JOIN VenueItems vi ON b.TableID = vi.TableID
            JOIN VenueOwners vo ON v.VenueID = vo.VenueID
            JOIN Users uvi ON vo.UserID = uvi.UserID
            JOIN status s ON b.status = s.ID
        WHERE 
            b.ID = @BID",
                new { BID = ID });

            return bookings.ToList();
        }

        [HttpGet("GetBookingsByUsername")]
        public async Task<ActionResult<IEnumerable<BookingsByDate>>> GetBookingsByUsername(string username)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var user = await con.QuerySingleOrDefaultAsync<Users>(
                "SELECT UserID FROM Users WHERE username = @Username", new { Username = username });
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var bookings = await con.QueryAsync<BookingsByDate>(@"
        SELECT 
            b.ID, 
            u.Firstname + ' ' + u.Lastname AS fullname, 
            u.Email, 
            u.Phone, 
            b.Pax AS pax, 
            vi.Pax AS tableSize, 
            vi.TableNr, 
            b.Note,
            b.Time, 
            v.name AS Venue, 
            uvi.Firstname + ' ' + uvi.Lastname AS venueOwner, 
            s.Status 
        FROM 
            bookings b 
            JOIN users u ON u.UserID = b.UserID 
            JOIN Venues v ON b.VenueID = v.VenueID
            JOIN VenueItems vi ON b.TableID = vi.TableID
            JOIN VenueOwners vo ON v.VenueID = vo.VenueID
            JOIN Users uvi ON vo.UserID = uvi.UserID
            JOIN status s ON b.status = s.ID
        WHERE 
            u.UserID = @UserID",
                new { UserID = user.UserID });

            return bookings.ToList();
        }

        [HttpGet("GetBookingsByVname")]
        public async Task<ActionResult<IEnumerable<BookingsByDate>>> GetBookingsByVname(string username, string venuename, string password)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var user = await con.QuerySingleOrDefaultAsync<UserLogin>(
                "SELECT * FROM UserLogin WHERE Username = @Username", new { Username = username });
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return BadRequest("Invalid password");
            }

            var bookings = await con.QueryAsync<BookingsByDate>(@"
        SELECT 
            b.ID, 
            u.Firstname + ' ' + u.Lastname AS fullname, 
            u.Email, 
            u.Phone, 
            b.Pax AS pax, 
            vi.Pax AS tableSize, 
            vi.TableNr, 
            b.Note,
            b.Time, 
            v.name AS Venue, 
            uvi.Firstname + ' ' + uvi.Lastname AS venueOwner, 
            s.Status 
        FROM 
            bookings b 
            JOIN users u ON u.UserID = b.UserID 
            JOIN Venues v ON b.VenueID = v.VenueID
            JOIN VenueItems vi ON b.TableID = vi.TableID
            JOIN VenueOwners vo ON v.VenueID = vo.VenueID
            JOIN Users uvi ON vo.UserID = uvi.UserID
            JOIN status s ON b.status = s.ID
        WHERE 
            v.Name = @venuename",
                new { venuename = venuename });

            return bookings.ToList();
        }

        [HttpGet("GetBookingsByDate")]
        public async Task<ActionResult<IEnumerable<BookingsByDate>>> GetBookingsByDate(string username, string venueName, DateTime date)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT VenueID FROM Venues WHERE Name = @VenueName", new { VenueName = venueName });
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

            var bookings = await con.QueryAsync<BookingsByDate>(@"
        SELECT 
            b.ID, 
            u.Firstname + ' ' + u.Lastname AS fullname, 
            u.Email, 
            u.Phone, 
            b.Pax AS pax, 
            vi.Pax AS tableSize, 
            vi.TableNr, 
            b.Note,
            b.Time, 
            v.name AS Venue, 
            uvi.Firstname + ' ' + uvi.Lastname AS venueOwner, 
            s.Status 
        FROM 
            bookings b 
            JOIN users u ON u.UserID = b.UserID 
            JOIN Venues v ON b.VenueID = v.VenueID
            JOIN VenueItems vi ON b.TableID = vi.TableID
            JOIN VenueOwners vo ON v.VenueID = vo.VenueID
            JOIN Users uvi ON vo.UserID = uvi.UserID
            JOIN status s ON b.status = s.ID
        WHERE 
            v.VenueID = @VenueID 
            AND CONVERT(date, b.time, 111) = @date",
                new { VenueID = venue.VenueID, Date = date.Date });

            return bookings.ToList();
        }



        // POST api/<BookingsController>
        [HttpPost("CreateBooking")]
        public async Task<ActionResult<Bookings>> CreateBooking(CreateBooking booking)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT VenueID FROM Venues WHERE Name = @VenueName", new { VenueName = booking.VenueName });
            if (venue == null)
            {
                return BadRequest("Venue does not exist");
            }

            var user = await con.QuerySingleOrDefaultAsync<Users>(
                "SELECT UserID FROM Users WHERE username = @Username", new { Username = booking.Username });
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var existingBooking = await con.QuerySingleOrDefaultAsync<Bookings>(
               "SELECT ID FROM Bookings WHERE UserID = @UserID AND VenueID = @VenueID AND cast(Time as date) = cast(@DateTime as date)",
               new { UserID = user.UserID, VenueID = venue.VenueID, DateTime = booking.DateTime });
            if (existingBooking != null)
            {
                return BadRequest("You already have a booking on this venue and date");
            }

            var table = await con.QuerySingleOrDefaultAsync<VenueItems>(
                "SELECT top 1 TableID FROM VenueItems WHERE VenueID = @VenueID AND Pax >= @Pax AND TableID NOT IN (SELECT TableID FROM Bookings WHERE cast(Time as date) = cast(@DateTime as date)) ORDER BY Pax",
                new { VenueID = venue.VenueID, Pax = booking.Pax, DateTime = booking.DateTime });
            if (table == null)
            {
                return BadRequest("No Table available for this booking");
            }

           

            var result = await con.ExecuteAsync(
                "INSERT INTO Bookings (UserID, VenueID, Time, Pax, Note, TableID, Status) VALUES (@UserID, @VenueID, @DateTime, @Pax, @Note, @TableID, 2)",
                new { UserID = user.UserID, VenueID = venue.VenueID, DateTime = booking.DateTime, Pax = booking.Pax, Note = booking.Note, TableID = table.TableID });
            if (result == 0)
            {
                return BadRequest("Failed to create booking");
            }

            return Ok();
        }


        // PUT api/<BookingsController>/5
        [HttpPut("UpdateBooking")]
        public async Task<ActionResult<Bookings>> UpdateBooking(UpdateBooking booking)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT VenueID FROM Venues WHERE Name = @VenueName", new { VenueName = booking.VenueName });
            if (venue == null)
            {
                return BadRequest("Venue does not exist");
            }

            var user = await con.QuerySingleOrDefaultAsync<Users>(
                "SELECT UserID FROM Users WHERE username = @Username", new { Username = booking.Username });
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            var existingBooking = await con.QuerySingleOrDefaultAsync<Bookings>(
                "SELECT * FROM Bookings WHERE ID = @ID", new { ID = booking.ID });
            if (existingBooking == null)
            {
                return BadRequest("Booking does not exist");
            }

            var table = await con.QuerySingleOrDefaultAsync<VenueItems>(
                "SELECT top 1 TableID FROM VenueItems WHERE VenueID = @VenueID AND Pax >= @Pax AND TableID NOT IN (SELECT TableID FROM Bookings WHERE cast(Time as date) = cast(@DateTime as date)) ORDER BY Pax",
                new { VenueID = venue.VenueID, Pax = booking.Pax, DateTime = booking.Datetime });
            if (table == null)
            {
                return BadRequest("No table available for this booking");
            }

            var result = await con.ExecuteAsync(
                "UPDATE Bookings SET Time = @Datetime, Pax = @Pax, Note = @Note, TableID = @TableID WHERE ID = @ID",
                new { Datetime = booking.Datetime, Pax = booking.Pax, Note = booking.Note, TableID = table.TableID, ID = booking.ID });
            if (result == 0)
            {
                return BadRequest("Failed to update booking");
            }

            return Ok("Booking successfully updated");
        }




        // PUT api/<BookingsController>/
        [HttpPut("UpdateBookingStatus/{id}")]
        public async Task<ActionResult<Bookings>> UpdateBookingStatus(int id, UpdateBookingStatus updateBookingStatus)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var booking = await con.QuerySingleOrDefaultAsync<Bookings>(
                "SELECT * FROM Bookings WHERE ID = @ID", new { ID = id });
            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            var venueOwner = await con.QuerySingleOrDefaultAsync<VenueOwners>(
                "SELECT UserID FROM VenueOwners WHERE VenueID = @VenueID AND UserID = (SELECT UserID FROM Users WHERE username = @username)",
                new { VenueID = booking.VenueID, Username = updateBookingStatus.Username });
            if (venueOwner == null)
            {
                return BadRequest("You are not an owner of this venue");
            }

            var result = await con.ExecuteAsync(
                "UPDATE Bookings SET status = @status WHERE ID = @ID",
                new { status = updateBookingStatus.Status, ID = id });
            if (result == 0)
            {
                return BadRequest("Failed to update booking status");
            }

            return Ok();
        }


        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id, string username, string password)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));

            var user = await con.QuerySingleOrDefaultAsync<UserLogin>(
                "SELECT * FROM UserLogin WHERE Username = @Username", new { Username = username });
            if (user == null)
            {
                return BadRequest("User does not exist");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return BadRequest("Invalid password");
            }

            var booking = await con.QuerySingleOrDefaultAsync<Bookings>(
                "SELECT * FROM Bookings WHERE ID = @ID", new { ID = id });
            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            var venue = await con.QuerySingleOrDefaultAsync<Venues>(
                "SELECT * FROM Venues WHERE VenueID = @VenueID", new { VenueID = booking.VenueID });
            if (venue == null)
            {
                return BadRequest("Venue not found");
            }

            var venueOwner = await con.QuerySingleOrDefaultAsync<VenueOwners>(
                "SELECT * FROM VenueOwners WHERE VenueID = @VenueID AND UserID = (SELECT UserID FROM Users WHERE username = @username)",
                new { VenueID = venue.VenueID, username = username });
            if (venueOwner == null)
            {
                return BadRequest("You are not an owner of this venue");
            }

            var result = await con.ExecuteAsync(
                "DELETE FROM Bookings WHERE ID = @ID", new { ID = id });
            if (result == 0)
            {
                return BadRequest("Failed to delete booking");
            }

            return Ok();
        }

    }
}
