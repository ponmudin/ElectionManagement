using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ElectionCommissioner")]
    public class CandidateController : ControllerBase
    {
        List<Candidate> candidates = new List<Candidate>()
        {
            new Candidate(){CandidateId=1, CandidateName="Ramesh", ConstituencyId=1, StateId=0, PartyId= 1},
            new Candidate(){CandidateId=2, CandidateName="Rakesh", ConstituencyId=1, StateId=0, PartyId= 1},
            new Candidate(){CandidateId=3, CandidateName="Rajesh", ConstituencyId=1, StateId=0, PartyId= 1},
        };

        [HttpGet]
        public IEnumerable<Candidate> Get()
        {
            return candidates;
        }

        [HttpPost]
        public void Post([FromBody] Candidate value)
        {
            if(value == null)
            {
                return;
            }

            candidates.Add(value);
        }
        
    }
}
