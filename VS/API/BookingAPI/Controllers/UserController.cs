using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookingAPI.Models;
using Newtonsoft.Json;


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
        [Route("CreateUser")]
        public JsonResult CreateUser(int AdminLevel, string Fname, string SName, string UserName, string Email, string Phone, string Region, string Birthday, string pass)
        {
            pass = BCrypt.Net.BCrypt.HashPassword(pass);

            string q = "exec CreateUser @AdminLvl,@firstname,@lastname,@username,@email,@phone,@region,@bday,@pass";



            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
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

                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }

            return new JsonResult("New employee added Succesfull");
        }


        [HttpGet("LogInCheck")]

        public string LogInCheck(string username,string password)
        {
            string q = @"select * from UserLogin where username ='" + username +"'";
            string p_;
            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
            List<UserLogin> ulList = new List<UserLogin>();
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

        public string GetAllUsers()
        {
            string q = "select * from users";

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


        [HttpGet("GetUser/{UserID}")]
        public string GetUser(int UserID)
        {
            string q = @"select * from users where userID =" + UserID + @"";

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

        [HttpPut("EditUser/{UserID}")]
        public String EditUser(int UserID, int? AdminLevel,string? Fname,string? SName, string? UserName, string? Email, string? Phone, string? Region, string? Birthday, string? pass)
        {
            if (pass != null)
            { pass = BCrypt.Net.BCrypt.HashPassword(pass); }

            string q = @"exec UpdateUser
                '" + AdminLevel + @"','"
                  + Fname + @"','"
                  + SName + @"','"
                  + UserName + @"','"
                  + Email + @"','"
                  + Phone + @"','"
                  + Region + @"','"
                  + Birthday + @"','"
                  + pass + @"','"
                  + UserID + @"'";

            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
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

            
            return JsonConvert.SerializeObject(dt);

        }

        [HttpDelete("DeleteUser/{UserID}")]
        public string DeleteUser(int UserID, int? adminL, string? pass)
        {
            string q = @"exec DeleteUser
                '" + adminL + @"','"
                   + UserID + @"','"
                   + pass + @"'";

            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            SqlDataReader sdr;
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
            return JsonConvert.SerializeObject(dt);

            
        }
    }
}

