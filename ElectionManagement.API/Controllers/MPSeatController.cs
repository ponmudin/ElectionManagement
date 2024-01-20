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
            new MPSeat(1, "Const1", (int)State.Tamilnadu),
            new MPSeat(2, "Const2", (int)State.Tamilnadu),
            new MPSeat(3, "Const3", (int)State.Tamilnadu),
            new MPSeat(4, "Const4", (int)State.Tamilnadu),
        };

        // GET: api/<MPSeatController>
        [HttpGet]
        public IEnumerable<MPSeat> Get()
        {
            return seats;
        }

        // POST api/<MPSeatController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //deserialize 
            MPSeat? seat = null;

            if (seat == null)
                return;

            seats.Add(seat);
        }
        

        // DELETE api/<MPSeatController>/5
        [HttpDelete("{id}")]
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
