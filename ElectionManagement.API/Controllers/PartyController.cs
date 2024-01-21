using Dapper;
using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        public SqliteConnection DbConnection { get; set; }

        public PartyController(IDatabaseContext context)
        {
            this.DbConnection = context.DbConnection;
        }

        [HttpGet]
        public Task<IEnumerable<Party>> GetParties()
        {
            var sql = "select * from Party";
            return DbConnection.QueryAsync<Party>(sql);
        }

        [HttpPost]
        //[Authorize(Roles = "ElectionCommissioner")]
        public IActionResult AddNewParty([FromBody] Party value)
        {
            if (value == null)
                return BadRequest();

            var sql = $"insert into Party(PartyName) values ('{value.PartyName}')";

            var result = DbConnection.ExecuteAsync(sql);

            return result.Result > 0 ? CreatedAtAction("AddNewParty", result.Result) : NoContent();
        }
       
    }
}
