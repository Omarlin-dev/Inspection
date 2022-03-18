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
    public class InspectionTypeController : ControllerBase
    {
        private readonly DataContext context;

        public InspectionTypeController(DataContext context)
        {
            this.context = context;
        }

        // GET: api/<InspectionTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            var lstInspectionType = context.InspectionTypes.ToList();

            return Ok(lstInspectionType);
        }

        // GET api/<InspectionTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!Existe(id))
            {
                return NotFound();
            }

            var InspectionType = context.InspectionTypes.Find(id);

            return Ok(InspectionType);
        }

        // POST api/<InspectionTypeController>
        [HttpPost]
        public IActionResult Post([FromBody] InspectionType inspectionType)
        {
            context.InspectionTypes.Add(inspectionType);
            context.SaveChanges();

            return Ok(inspectionType);
        }

        // PUT api/<InspectionTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InspectionType inspectionType)
        {

            if (!(Existe(id) && Existe(inspectionType.Id)))
            {
                return NotFound();
            }

            if(!context.Inspections.Any(d => d.InspectionTypeId == id))
            {
                return BadRequest();
            }

            context.Entry(inspectionType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok(inspectionType);

        }

        // DELETE api/<InspectionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!Existe(id))
            {
                return NotFound();
            }

            if (context.Inspections.Any(d => d.InspectionTypeId == id))
            {
                return BadRequest();
            }

            var inspectionType = context.InspectionTypes.Find(id);

            context.InspectionTypes.Remove(inspectionType);
            context.SaveChanges();

            return Ok(inspectionType);
        }

        private bool Existe(int Id)
        {
            return context.InspectionTypes.Any(d => d.Id == Id);
        }
    }
}
