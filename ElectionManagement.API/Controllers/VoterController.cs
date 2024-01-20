using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ElectionManagement.API.Models.MPSeat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        List<Voter> voters = new List<Voter>()
        {
            new Voter(){VoterId = 1, VoterName="aarav", Address="", ConstituencyId = 1, StateId=1, IsApproved=false },
            new Voter(){VoterId = 1, VoterName="kishore", Address="", ConstituencyId = 2, StateId=1, IsApproved=false },
            new Voter(){VoterId = 1, VoterName="raju", Address="", ConstituencyId = 3, StateId=1, IsApproved=false },
        };

        List<Voting> electionResult = new List<Voting>();

        [HttpGet("GetVoters")]
        public IEnumerable<Voter> Get()
        {
            return voters;
        }

        [HttpGet("GetElectionResult")]
        public IEnumerable<Voting> GetElectionResult()
        {
            return electionResult;
        }


        [HttpPost(Name ="AddVoter")]
        public void Post([FromBody] Voter value)
        {
            if(value == null)
            {
                return;
            }

            voters.Add(value);
        }

        [HttpPost(Name ="CastVote")]
        public void CastVote([FromBody] Voting value)
        {
            if (value == null)
            {
                return;
            }

            electionResult.Add(value);
        }


        [HttpPut("{id}")]
        //[Authorize(Roles = "ElectionCommissioner")]
        public void ApproveVoter(int id, [FromBody] Voter value)
        {
            Voter? voter = voters.Find(x => x.VoterId == id);

            if (voter == null)
                return;

            voter.IsApproved = true ;
        }

    }
}
