using InspectionApi.Data;
using InspectionApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace InspectionApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("miAllowSpecificOrigins")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext context;

        public StatusController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public IActionResult Get()
        {
            var lstStatus = context.Statuses.ToList();

            return Ok(lstStatus);
        }

        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!Existe(id))
            {
                return NotFound();
            }

            var status = context.Statuses.Find(id);

            return Ok(status);
        }

        // POST api/<StatusController>
        [HttpPost]
        public IActionResult Post([FromBody] Status status)
        {
            context.Statuses.Add(status);
            context.SaveChanges();

            return Ok(status);
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Status status)
        {

            if (!(Existe(id) && Existe(status.Id)))
            {
                return NotFound(); 
            }

            context.Entry(status).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok(status);

        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!Existe(id))
            {
                return NotFound();
            }

            var status = context.Statuses.Find(id);

            context.Statuses.Remove(status);
            context.SaveChanges();

            return Ok(status);
        }

        private bool Existe(int Id)
        {
            return context.Statuses.Any(d => d.Id == Id);
        }
    }
}
