using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class UserBookController : ControllerBase
    {
        public prContext Context { get; }
        public UserBookController(prContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserBook> userBook = Context.UserBooks.ToList();
            return Ok(userBook);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UserBook? userBook = Context.UserBooks.Where(x => x.IdUserBook == id).FirstOrDefault();
            if (userBook == null)
            {
                return BadRequest("Not found");
            }
            return Ok(userBook);
        }
        [HttpPost]
        public IActionResult Add(UserBook userBook)
        {
            Context.UserBooks.Add(userBook);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UserBook userBook)
        {
            Context.UserBooks.Update(userBook);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            UserBook? userBook = Context.UserBooks.Where(x => x.IdUserBook == id).FirstOrDefault();
            if (userBook == null)
            {
                return BadRequest("Not found");
            }
            Context.UserBooks.Remove(userBook);
            Context.SaveChanges();
            return Ok();
        }
    }
}
