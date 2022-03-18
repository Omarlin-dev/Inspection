using InspectionApi.Data;
using InspectionApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace InspectionApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("miAllowSpecificOrigins")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private readonly DataContext context;

        public InspectionController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/<InspectionController>
        [HttpGet]
        public IActionResult Get()
        {
            var lstInspection= context.Inspections.ToList();

            return Ok(lstInspection);
        }

        // GET api/<InspectionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!Existe(id))
            {
                return NotFound();
            }

            var Inspection= context.Inspections.Find(id);

            return Ok(Inspection);
        }

        // POST api/<InspectionController>
        [HttpPost]
        public IActionResult Post([FromBody] Inspection inspection)
        {
            if (!context.InspectionTypes.Any(d => d.Id == inspection.InspectionTypeId))
            {
                return BadRequest();
            }

            context.Inspections.Add(inspection);
            context.SaveChanges();

            return Ok(inspection);
        }

        // PUT api/<InspectionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Inspection inspection)
        {

            if (!(Existe(id) && Existe(inspection.Id)))
            {
                return NotFound();
            }

            context.Entry(inspection).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok(inspection);

        }

        // DELETE api/<InspectionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!Existe(id))
            {
                return NotFound();
            }

            var inspection = context.Inspections.Find(id);

            context.Inspections.Remove(inspection);
            context.SaveChanges();

            return Ok(inspection);
        }

        private bool Existe(int Id)
        {
            return context.Inspections.Any(d => d.Id == Id);
        }
    }
}
