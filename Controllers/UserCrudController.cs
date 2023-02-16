using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller: ControllerBase
    {
        private readonly UserDb _userDb;
        
        public Controller(UserDb userDb)
        {
            _userDb = userDb;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserData user)
        {
            await _userDb.Add(user);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await _userDb.GetAll();
            if(userList==null)
            {
                return NotFound();
            }
            return Ok(userList);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserData update)
        {
            var user=await _userDb.Get(update.id);
            if(user==null)
            {
                return NotFound();
            }
            await _userDb.Update(update);
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userDb.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userDb.Delete(id);
            return Ok();
        }
    }
}
