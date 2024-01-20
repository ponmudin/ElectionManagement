using ElectionManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using static ElectionManagement.API.Models.MPSeat;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MPSeatController : ControllerBase
    {
        List<MPSeat> seats = new List<MPSeat>() { 
            new MPSeat(){ ConstituencyId= 1, ConstituencyName= "Const1", StateId= (int)State.Tamilnadu},
            new MPSeat(){ ConstituencyId= 2, ConstituencyName= "Const2", StateId= (int)State.Tamilnadu},
            new MPSeat(){ ConstituencyId= 3, ConstituencyName= "Const3", StateId= (int)State.Tamilnadu},
            new MPSeat(){ ConstituencyId= 4, ConstituencyName= "Const4", StateId= (int)State.Tamilnadu},
        };

        [HttpGet]
        public IEnumerable<MPSeat> Get()
        {
            return seats;
        }

        [HttpPost]
        //[Authorize(Roles = "ElectionCommissioner")]
        public void Post([FromBody] MPSeat seat)
        {
            if (seat == null)
                return;

            seats.Add(seat);
        }
        

        [HttpDelete("{id}")]
        //[Authorize(Roles = "ElectionCommissioner")]
        public void Delete(int id)
        {
            MPSeat? seat = seats.Find(x => x.ConstituencyId == id);

            if (seat == null)
                return;

            int index = seats.IndexOf(seat);
            seats.RemoveAt(index);
        }
    }
}
