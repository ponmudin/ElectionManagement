using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectionManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionResultController : ControllerBase
    {
        // GET: api/<ElectionResultController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ElectionResultController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ElectionResultController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ElectionResultController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ElectionResultController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
