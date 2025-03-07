using AssessmentApp.Models;
using AssessmentApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AssessmentApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentController : ControllerBase
    {
        private readonly AssessmentService _service;

        public AssessmentController(AssessmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Assessment> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Assessment> Get(int id)
        {
            var assessment = _service.GetById(id);
            if (assessment == null)
            {
                return NotFound();
            }
            return assessment;
        }

        [HttpPost]
        public ActionResult<Assessment> Post(Assessment assessment)
        {
            _service.Add(assessment);
            return CreatedAtAction(nameof(Get), new { id = assessment.Id }, assessment);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Assessment assessment)
        {
            if (id != assessment.Id)
            {
                return BadRequest();
            }
            _service.Update(assessment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}