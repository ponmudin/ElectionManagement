using Dapper;
using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using static ElectionManagement.API.Models.MPSeat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MPSeatController : ControllerBase
    {
        public SqliteConnection DbConnection { get; set; }

        public MPSeatController(IDatabaseContext context)
        {
            this.DbConnection = context.DbConnection;
        }

        [HttpGet]
        public Task<IEnumerable<MPSeat>> GetMPSeats()
        {
            var sql = "select * from MPSeat";
            return DbConnection.QueryAsync<MPSeat>(sql);
        }

        [HttpPost]
        //[Authorize(Roles = "ElectionCommissioner")]
        public IActionResult AddNewMPSeat([FromBody] MPSeat value)
        {
            if (value == null)
                return BadRequest();

            var sql = $"insert into MPSeat(ConstituencyName, StateId) values ('{value.ConstituencyName}', '{value.StateId}')";

            var result = DbConnection.ExecuteAsync(sql);

            return result.Result > 0 ? CreatedAtAction("AddNewMPSeat", result.Result) : NoContent();
        }
        

        [HttpDelete("{id}")]
        //[Authorize(Roles = "ElectionCommissioner")]
        public IActionResult DeleteMPSeat(int id)
        {
            var sql = $"delete from MPSeat where SeatId = {id}";

            var result = DbConnection.ExecuteAsync(sql);

            return result.Result > 0 ? Ok() : NoContent();
        }
    }
}
