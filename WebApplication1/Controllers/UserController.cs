using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public prContext Context { get; }
        public UserController(prContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> user = Context.Users.ToList();
            return Ok(user);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.IdUser == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not found");
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.IdUser == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
}
