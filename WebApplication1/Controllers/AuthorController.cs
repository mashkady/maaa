using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        public prContext Context { get; }
        public AuthorController(prContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Author> author = Context.Authors.ToList();
            return Ok(author);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Author? author = Context.Authors.Where(x => x.IdAuthor == id).FirstOrDefault();
            if (author == null)
            {
                return BadRequest("Not found");
            }
            return Ok(author);
        }
        /// <summary>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///         "name" : "Пушкин",
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(string author)
        {
            Context.Authors.FirstOrDefault(x => x.Name == author);
            Context.Authors.Add(new Author() { Name=author});
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Author author)
        {
            Context.Authors.Update(author);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Author? author = Context.Authors.Where(x => x.IdAuthor == id).FirstOrDefault();
            if (author == null)
            {
                return BadRequest("Not found");
            }
            Context.Authors.Remove(author);
            Context.SaveChanges();
            return Ok();
        }
    }
}
