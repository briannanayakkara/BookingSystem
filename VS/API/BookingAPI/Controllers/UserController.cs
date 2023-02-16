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


        [HttpPost] 
        [Route("CreateUser/{AdminLevel}/{Fname}/{SName}/{UserName}/{Email}/{Phone}/{Region}/{Birthday}/{pass}")]
        public async Task<ActionResult<JsonResult>> CreateUser(int AdminLevel, string Fname, string SName, string UserName, string Email, string Phone, string Region, string Birthday, string pass)
        {
            pass = BCrypt.Net.BCrypt.HashPassword(pass);

            string q = "exec CreateUser @AdminLvl,@firstname,@lastname,@username,@email,@phone,@region,@bday,@pass";



            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
           await using (SqlConnection cnn = new SqlConnection(con))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(q, cnn))
                {
                    cmd.Parameters.Add("@AdminLvl", SqlDbType.Int).Value = AdminLevel;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = Fname;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = SName;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UserName;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = Phone;
                    cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = Region;
                    cmd.Parameters.Add("@bday", SqlDbType.VarChar).Value = Birthday;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }

            return new JsonResult("New employee added Succesfull");
        }


        [HttpGet("LogInCheck")]

        public async Task<ActionResult<string>> LogInCheck(string username,string password)
        {
            string q = @"select * from UserLogin where username = @username";
            
            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
            List<UserLogin> ulList = new List<UserLogin>();
            Response r = new Response();
            await using (SqlConnection cnn = new SqlConnection(con))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(q, cnn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;

                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }
            if (dt.Rows.Count > 0)
            {
                UserLogin ul = new UserLogin();
                ul.UserName = Convert.ToString(dt.Rows[0]["Username"]);
                ul.Password = Convert.ToString(dt.Rows[0]["password"]);
                ulList.Add(ul);
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, ul.Password);

                if (isValidPassword)
                {
                    return JsonConvert.SerializeObject("Log in successfull");

                }
                else return JsonConvert.SerializeObject("invalid password");
            }
            else
            {
                r.StatusCode = 100;
                r.Message = "No Data found";
                return JsonConvert.SerializeObject(r);

            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {

            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            IEnumerable<Users> u = await SelectAllUsers(con);

            return Ok(u);
        }
      

        private static async Task<IEnumerable<Users>> SelectAllUsers(SqlConnection con)
        {
            return await con.QueryAsync<Users>("select * from Users");
        }

        [HttpGet("GetUser/{UserID}")]
        public async Task<ActionResult<List<Users>>> GetUser(int UserID)
        {

            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.QueryAsync<Users>("select * from users where userID = @userID", new { userID = UserID });

            return Ok(u);
        }

        [HttpPut("EditUser/{UserID}/{AdminLevel}/{Fname}/{SName}/{UserName}/{Email}/{Phone}/{Region}/{Birthday}/{pass}")]
        public String EditUser(int UserID, int? AdminLevel, string? Fname, string? SName, string? UserName, string? Email, string? Phone, string? Region, string? Birthday, string? pass)
        {
            if (pass != null)
            { pass = BCrypt.Net.BCrypt.HashPassword(pass); }
            

            string q = @"exec [UpdateUser] @AdminLvl,@firstname,@lastname,@username,@email,@phone,@region,@bday,@pass,@ID";
            
            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
            using (SqlConnection cnn = new SqlConnection(con))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(q, cnn))
                {
                    cmd.Parameters.Add("@AdminLvl", SqlDbType.Int).Value = AdminLevel;
                    cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = Fname;
                    cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = SName;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UserName;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = Phone;
                    cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = Region;
                    cmd.Parameters.Add("@bday", SqlDbType.VarChar).Value = Birthday;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = UserID;

                    sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }

            
            return JsonConvert.SerializeObject(dt);

        }

        [HttpDelete("DeleteUser/{UserID}")]
        public async Task<ActionResult<List<Users>>> DeleteUser(int UserID)
        {

            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            await con.ExecuteAsync("exec DeleteUser @ID", new { ID = UserID});
            return Ok(await SelectAllUsers(con));
        }

       
    }

    //internal record NewRecord(string Pass);
}

