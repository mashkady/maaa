using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        public prContext Context { get; }
        public ExchangeController(prContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Exchange> exchange = Context.Exchanges.ToList();
            return Ok(exchange);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Exchange? exchange = Context.Exchanges.Where(x => x.IdExchange == id).FirstOrDefault();
            if (exchange == null)
            {
                return BadRequest("Not found");
            }
            return Ok(exchange);
        }
        [HttpPost]
        public IActionResult Add(Exchange exchange)
        {
            Context.Exchanges.Add(exchange);
            Context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Exchange exchange)
        {
            Context.Exchanges.Update(exchange);
            Context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Exchange? exchange = Context.Exchanges.Where(x => x.IdExchange == id).FirstOrDefault();
            if (exchange == null)
            {
                return BadRequest("Not found");
            }
            Context.Exchanges.Remove(exchange);
            Context.SaveChanges();
            return Ok();
        }
    }
}
