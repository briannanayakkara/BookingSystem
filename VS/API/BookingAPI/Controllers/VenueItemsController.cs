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
        // GET: api/<VenueItemsController>
        [HttpGet("AllVenueItems")]
        public async Task<ActionResult<List<VenueItems>>> GetAllVenuesItems()
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.QueryAsync<VenueItems>("select * from VenueItems");
            return Ok(u);

        }

        // GET api/<VenueItemsController>/5
        [HttpGet("GetVenueItemByTableID/{ID}")]
        public async Task<ActionResult<List<VenueItems>>> GetVenueItemByTableID(int ID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.QueryAsync<VenueItems>("select * from VenueItems where TableID = @id", new { id = ID });
            return Ok(u);

        }

        // POST api/<VenueItemsController>
        [HttpPost("CreateVI")]
        public async Task<ActionResult<List<CreateVi>>> CreateVI(CreateVi VenueI)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.ExecuteAsync("exec [CreateVenueItem] @username,@VName,@TableNr,@Pax,@Type", VenueI);
            return Ok(u);
        }

        // PUT api/<VenueItemsController>/5
        //exec [UpdateVenueItem] @username,@VName,@TableNr,@Pax,@Type,@tableID
        [HttpPut("UpdateVI")]
        public async Task<ActionResult<List<CreateVi>>> UpdateVI(UpdateVi VenueI)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.ExecuteAsync("exec [UpdateVenueItem] @username,@VName,@TableNr,@Pax,@Type,@tableID", VenueI);
            return Ok(u);
        }

        //exec [DeleteVenueItem] @username,@VName,@tableID
        // DELETE api/<VenueItemsController>/5
        [HttpDelete("DeleteVI/{TableID}")]
        public async Task<ActionResult<List<CreateVi>>> DeleteVI(string UserName,string VenueName,int TableID)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("BookingSystem"));
            var u = await con.ExecuteAsync("exec [DeleteVenueItem] @username,@VName,@tableID", new { username = UserName, VName = VenueName, tableID = TableID });
            return Ok(u);
        }
    }
}
