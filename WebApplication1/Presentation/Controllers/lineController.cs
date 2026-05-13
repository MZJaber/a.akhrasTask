using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : Controller
    {
        private readonly LineServices _lineServices;

        public LineController(LineServices lineServices)
        { _lineServices = lineServices; }


     [HttpGet]
        public IActionResult GetAllLine()
        {

            var Lines = _lineServices.GetAllLine();

            return Ok(Lines);
        }





        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var line = _lineServices.Get(id);
            if (line == null)
            {
                return NotFound();

            }
            return Ok(line);
        }







        [HttpPost]
        public IActionResult AddLine([FromBody] LineModel model)
        {
            if (model == null)
                return BadRequest();

           
            var newLine = _lineServices.AddLine(model);
            return CreatedAtAction(nameof(Get), new { Id = newLine.id }, newLine);

        }



        [HttpPut("{id}")]

        public IActionResult UpdateLine(int id, [FromBody] LineModel line)
        {
            if (line == null)
                return BadRequest();
            _lineServices.UpdateLine(id, line);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLine(int id)
        {
            _lineServices.DeleteLine(id);
            return NoContent();

        }





    }
}
