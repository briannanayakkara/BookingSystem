using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookingAPI.Models;
using Newtonsoft.Json;
using Dapper;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var result = await con.QueryAsync<Users>("select * from Users");
            return Ok(result);
        }

        [HttpGet("GetUser/{UserID}")]
        public async Task<ActionResult<Users>> GetUser(int UserID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var result = await con.QueryFirstOrDefaultAsync<Users>("select * from Users where UserID = @ID", new { ID = UserID });
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("User not found.");
            }
        }


        [HttpGet("LogInCheck")]
        public async Task<IActionResult> LogInCheck(string username, string password)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("BookingSystem")))
            {
                var user = await connection.QueryFirstOrDefaultAsync<UserLogin>("SELECT * FROM UserLogin WHERE Username = @Username", new { Username = username });
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return Ok("Login successful.");
                }
                else
                {
                    return BadRequest("Invalid password.");
                }
            }
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserData userData)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(userData.Password);

            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var existingUser = await con.QueryFirstOrDefaultAsync<UserData>("SELECT * FROM Users WHERE username = @username", new { username = userData.Username });

            if (existingUser != null)
            {
                return BadRequest("A user with the same username already exists.");
            }

            var parameters = new DynamicParameters();
            parameters.Add("@username", userData.Username, DbType.String);
            parameters.Add("@firstname", userData.Firstname, DbType.String);
            parameters.Add("@lastname", userData.Lastname, DbType.String);
            parameters.Add("@email", userData.Email, DbType.String);
            parameters.Add("@phone", userData.Phone, DbType.Int32);
            parameters.Add("@region", userData.Region, DbType.String);
            parameters.Add("@bday", userData.Bday, DbType.DateTime);
            parameters.Add("@AdminLvl", userData.AdminLvl, DbType.Int32);
            parameters.Add("@pass", password, DbType.String);
            parameters.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await con.ExecuteAsync("INSERT INTO Users(Username,Firstname,Lastname,Email,Phone,Region,Birthday,AdminLevel) SELECT @username,@firstname,@lastname,@email,@phone,@region,@bday,@AdminLvl; SET @ID = (SELECT UserID FROM Users WHERE username = @username); INSERT INTO UserLogin(UserID,Username,password) SELECT @ID,@username,@pass", parameters);
            var userID = parameters.Get<int>("@ID");

            if (userID > 0)
            {
                return Ok("User created successfully.");
            }
            else
            {
                return StatusCode(500, "Failed to create user.");
            }
        }


        [HttpPut("EditUser/{UserID}")]
        public async Task<IActionResult> EditUser(int UserID, [FromBody] UserData userData)
        {
            var password = BCrypt.Net.BCrypt.HashPassword(userData.Password);

            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var parameters = new DynamicParameters();
            parameters.Add("@ID", UserID, DbType.Int32);
            parameters.Add("@AdminLvl", userData.AdminLvl, DbType.Int32);
            parameters.Add("@firstname", userData.Firstname, DbType.String);
            parameters.Add("@lastname", userData.Lastname, DbType.String);
            parameters.Add("@username", userData.Username, DbType.String);
            parameters.Add("@email", userData.Email, DbType.String);
            parameters.Add("@phone", userData.Phone, DbType.Int32);
            parameters.Add("@region", userData.Region, DbType.String);
            parameters.Add("@bday", userData.Bday, DbType.DateTime);
            parameters.Add("@pass", password, DbType.String);

            await con.ExecuteAsync("IF (isnull(@AdminLvl,'') = '') BEGIN SET @AdminLvl = (SELECT AdminLevel FROM users WHERE UserID = @ID) END IF (isnull(@firstname,'') = '') BEGIN SET @firstname = (SELECT Firstname FROM users WHERE UserID = @ID) END IF (isnull(@lastname,'') = '') BEGIN SET @lastname = (SELECT Lastname FROM users WHERE UserID = @ID) END IF (isnull(@username,'') = '') BEGIN SET @username = (SELECT Username FROM Users WHERE UserID = @ID) END IF (isnull(@email,'') = '') BEGIN SET @email = (SELECT Email FROM Users WHERE UserID = @ID) END IF (@phone IS NULL) OR (@phone = '') BEGIN SET @phone = (SELECT Phone FROM Users WHERE UserID = @ID) END IF (isnull(@region,'') = '') BEGIN SET @region = (SELECT Region FROM Users WHERE UserID = @ID) END IF (isnull(@bday,'') = '') BEGIN SET @bday = (SELECT Birthday FROM Users WHERE UserID = @ID) END IF (isnull(@pass,'') = '') BEGIN SET @pass = (SELECT password FROM UserLogin WHERE UserID = @ID) END IF EXISTS (SELECT * FROM users WHERE UserID = @ID) BEGIN UPDATE Users SET Username = @username, firstname = @firstname, lastname = @lastname, Email = @email, Phone = @phone, Region = @region, Birthday = @bday, AdminLevel = @AdminLvl WHERE UserID = @ID UPDATE UserLogin SET password = @pass, Username = @username WHERE UserID = @ID END", parameters);

            return Ok("User edited successfully.");
        }

        [HttpDelete("DeleteUser/{UserID}")]
        public async Task<ActionResult<List<string>>> DeleteUser(int UserID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var result = await con.QueryFirstOrDefaultAsync<string>("exec DeleteUser @ID", new { ID = UserID });
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, "Failed to delete user.");
            }
        }


    }
}

