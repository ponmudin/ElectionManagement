using Dapper;
using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using static ElectionManagement.API.Models.MPSeat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        public SqliteConnection DbConnection { get; set; }

        public VoterController(IDatabaseContext context)
        {
            this.DbConnection = context.DbConnection;
        }

        [HttpGet("GetVoters")]
        public Task<IEnumerable<Voter>> GetVoters()
        {
            var sql = "select * from Voter";
            return DbConnection.QueryAsync<Voter>(sql);
        }

        [HttpPost("RegisterVoter")]
        public IActionResult RegisterVoter([FromBody] Voter value)
        {
            if (value == null)
                return BadRequest();

            var sql = $"insert into Voter(VoterName, ConstituencyId) values ('{value.VoterName}', {value.ConstituencyId})";

            var result = DbConnection.ExecuteAsync(sql);

            return result.Result > 0 ? CreatedAtAction("RegisterVoter", result.Result) : NoContent();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "ElectionCommissioner")]
        public IActionResult ApproveVoter(int id)
        {
            var sql = $"update Voter set isApproved = true where voterId = {id}";

            var result = DbConnection.ExecuteAsync(sql);

            return result.Result > 0 ? Ok() : NoContent();
        }


        [HttpPost("CastVote")]
        public IActionResult CastVote([FromBody] Election value)
        {
            if (value == null)
                return BadRequest();

            var sql = $"insert into Election(VoterId, CandidateId, VotedDateTime) values ({value.VoterId}, {value.CandidateId}, '{DateTime.Now}')";

            var result = DbConnection.ExecuteAsync(sql);

            return result.Result > 0 ? CreatedAtAction("CastVote", result.Result) : NoContent();
        }

        [HttpGet("GetElectionResult")]
        public Task<IEnumerable<dynamic>> GetElectionResult()
        {
            var sql = "select pt.PartyName, count(el.CandidateId) as VoteCount from Election el " +
                               "join Candidate cd ON el.CandidateId = cd.CandidateId " +
                                "join Party pt ON pt.PartyId = cd.PartyId " +
                                "group by pt.PartyName" ;
            return DbConnection.QueryAsync(sql);
        }

    }
}
