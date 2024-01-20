using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        List<ElectionParty> parties = new List<ElectionParty>()
        {
            new ElectionParty(){ PartyId = 1, PartyName="ajp", PartySymbol=""},
            new ElectionParty(){ PartyId = 2, PartyName="bjp", PartySymbol=""},
        };

        [HttpGet]
        public IEnumerable<ElectionParty> Get()
        {
            return parties;
        }
       

        [HttpPost]
        //[Authorize(Roles = "ElectionCommissioner")]
        public void Post([FromBody] ElectionParty value)
        {
            if (value == null)
                return;

            parties.Add(value);
        }
       
    }
}
