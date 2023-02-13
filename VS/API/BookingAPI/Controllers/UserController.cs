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
            string q = @"exec CreateUser
                '" + AdminLevel + @"','"
                + Fname + @"','"
                + SName + @"','"
                + UserName + @"','"
                + Email + @"','"
                + Phone + @"','"
                + Region + @"','"
                + Birthday + @"','"
                + pass + @"'";
         

            DataTable dt = new DataTable();
            string con = _configuration.GetConnectionString("BookingSystem");
            using (SqlConnection cnn = new SqlConnection(con))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(q, cnn))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);
                    sdr.Close();
                    cnn.Close();

                }
            }

            return new JsonResult("New employee added Succesfull");
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

            //return JsonConvert.SerializeObject(q);
            return JsonConvert.SerializeObject("Eployee " + UserName + " has been updated");
        }

        [HttpDelete("DeleteUser/{UserID}")]
        public JsonResult DeleteUser(int UserID, int? adminL, string? pass)
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

            return new JsonResult(q);
           // return new JsonResult("Employee ID = " + UserID + " has been removed from the DB");
        }
    }
}

