using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        public prContext Context { get; }
        public BookController(prContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> book = Context.Books.ToList();
            return Ok(book);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Book? book = Context.Books.Where(x => x.IdBook == id).FirstOrDefault();
            if (book == null)
            {
                return BadRequest("Not found");
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Add(string book)
        {
            Context.Books.FirstOrDefault(x => x.Name == book);
            Context.Books.Add(new Book() { Name = book });
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            Context.Books.Update(book);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Book? book = Context.Books.Where(x => x.IdBook == id).FirstOrDefault();
            if (book == null)
            {
                return BadRequest("Not found");
            }
            Context.Books.Remove(book);
            Context.SaveChanges();
            return Ok();
        }
    }
}
