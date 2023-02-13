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
        public JsonResult CreateUser(Users e, string pass)
        {
            string q = @"exec CreateUser 
                '" + e.AdminLevel + @"','"
                  + e.FName + @"','"
                  + e.SName + @"','"
                  + e.UserName + @"','"
                  + e.Email + @"','"
                  + e.Phone + @"','"
                  + e.Region + @"','"
                  + e.Birthday + @"','"
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

        [HttpGet]
        [Route("GetAllUsers")]

        public string GetAllUsers()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("BookingSystem").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM USERS", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Users> usersList = new List<Users>();
            Response r = new Response();
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user = new Users();
                    user.Id = Convert.ToInt32(dt.Rows[i]["UserID"]);
                    user.UserName = Convert.ToString(dt.Rows[i]["Username"]);
                    user.FName = Convert.ToString(dt.Rows[i]["Firstname"]);
                    user.SName = Convert.ToString(dt.Rows[i]["Lastname"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Phone = Convert.ToString(dt.Rows[i]["Phone"]);
                    user.Region = Convert.ToString(dt.Rows[i]["Region"]);
                    user.Birthday = Convert.ToString(dt.Rows[i]["Birthday"]);
                    user.AdminLevel = Convert.ToInt32(dt.Rows[i]["AdminLevel"]);
                }
            }
            if (usersList.Count > 0)
                return JsonConvert.SerializeObject(usersList);
            else
            {
                r.StatusCode = 100;
                r.Message = "No Data Found";
                return JsonConvert.SerializeObject(r);
            }
        }


        [HttpGet("GetUser/{UserID}")]
        public JsonResult GetUser(int UserID)
        {
            string q = @"select * from users where userID =" + UserID + @"";

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

            return new JsonResult(dt);
        }

        [HttpPut("EditUser/{UserID}")]
        public JsonResult EditUser(int UserID, Users e, string pass)
        {
            string q = @"exec UpdateUser
                '" + e.AdminLevel + @"','"
                  + e.FName + @"','"
                  + e.SName + @"','"
                  + e.UserName + @"','"
                  + e.Email + @"','"
                  + e.Phone + @"','"
                  + e.Region + @"','"
                  + e.Birthday + @"','"
                  + pass + @"','"
                  + e.Id + @"'";

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

            return new JsonResult("Eployee " + e.UserName + " has been updated");
        }

        [HttpDelete("DeleteUser/{UserID}")]
        public JsonResult DeleteUser(int UserID, int adminL, string pass)
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

            return new JsonResult("Employee ID = " + UserID + " has been removed from the DB");
        }
    }
}

