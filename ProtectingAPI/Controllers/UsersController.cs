using Microsoft.AspNetCore.Mvc;
using ProtectingAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProtectingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore =false)] //use caching data does not chane frequently. //modified caching time 60*60*24 (for a day)
        public IEnumerable<string> Get()
        {
            return new string[] { Random.Shared.Next(1,101).ToString() };
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
       // [ResponseCache(Duration = 20, Location = ResponseCacheLocation.Any, NoStore = false)] //use caching data does not chane frequently.

        public string Get(int id)
        {
            return $"Random Number: {Random.Shared.Next(1,101)} for Id {id}";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel value)
        {
            if (ModelState.IsValid)
            {
                return Ok("The model was valid");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
