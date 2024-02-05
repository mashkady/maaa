using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class JanreController : ControllerBase
    {
        public prContext Context { get; }
        public JanreController(prContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Janre> janre = Context.Janres.ToList();
            return Ok(janre);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Janre? janre = Context.Janres.Where(x => x.IdJanre == id).FirstOrDefault();
            if (janre == null)
            {
                return BadRequest("Not found");
            }
            return Ok(janre);
        }
        [HttpPost]
        public IActionResult Add(string janre)
        {
            Context.Janres.FirstOrDefault(x => x.Name == janre);
            Context.Janres.Add(new Janre() { Name = janre });
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Janre janre)
        {
            Context.Janres.Update(janre);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Janre? janre = Context.Janres.Where(x => x.IdJanre == id).FirstOrDefault();
            if (janre == null)
            {
                return BadRequest("Not found");
            }
            Context.Janres.Remove(janre);
            Context.SaveChanges();
            return Ok();
        }
    }
}
