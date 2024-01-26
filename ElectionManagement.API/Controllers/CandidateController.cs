using Dapper;
using ElectionManagement.API.Filters;
using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ElectionCommissioner")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        public SqliteConnection DbConnection { get; set; }

        public CandidateController(IDatabaseContext context, ILogger<CandidateController> logger)
        {
            this.DbConnection = context.DbConnection;
            _logger = logger;
        }

        [HttpGet]
        [ServiceFilter(typeof(ExceptionFilter))]
        public Task<IEnumerable<Candidate>> GetCandidates()
        {
            _logger.LogInformation(nameof(GetCandidates), DateTime.UtcNow.ToLongTimeString());
            var sql = "select * from Candidate";
            return DbConnection.QueryAsync<Candidate>(sql);
        }

        [HttpGet("{id}")]
        public Task<IEnumerable<dynamic>> GetCandidatesByConstituency(int id)
        {
            var sql = $"select cd.CandidateId, cd.CandidateName, pt.PartyName, mp.ConstituencyId, mp.ConstituencyName from Candidate cd " +
                                 $"join Party pt on cd.PartyId = pt.PartyId " +
                                 $"join MPSeat mp on mp.ConstituencyId = cd.ConstituencyId " +
                                 $"where cd.ConstituencyId = {id} ";
            return DbConnection.QueryAsync(sql);
        }

        [HttpPost]
        //[Authorize(Roles = "ElectionCommissioner")]
        //[ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult AddNewCandidate([FromBody] Candidate value)
        {
            if (value == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var sql = $"insert into Candidate(CandidateName, PartyId, ConstituencyId) values ('{value.CandidateName}', {value.PartyId}, {value.ConstituencyId})";

            var result = DbConnection.ExecuteAsync(sql);

            return result.Result > 0 ? CreatedAtAction("AddNewCandidate", result.Result) : NoContent();
        }
    }

}
