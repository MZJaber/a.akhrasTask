using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class FloorController : Controller
   {
        private readonly FloorServices _floorServices;



        public FloorController(FloorServices floorServices)
        {
            _floorServices = floorServices;
        }

        [HttpGet]
        public IActionResult GetAllFloor()
        {
            
           
            var Floors = _floorServices.GetAllFloor();

            return Ok( Floors);
        }
        

    [HttpGet("{id}")]
        public ActionResult GetFloor(int id)
        {
           
            var floor = _floorServices.GetFloor(id);
            if (floor == null)
            {
                return NotFound();

            }
            return Ok(floor);
        }






    [HttpPost]
       public IActionResult CreateFloor([FromBody] FloorModel model)
       {
            if (model == null)
                return BadRequest();

            //_floorServices.Add(model);
            var newFloor = _floorServices.Add(model);
            return CreatedAtAction(nameof(GetFloor), new { id = newFloor.Id }, newFloor);

       }
      



    [HttpPut("{id}")]

        public IActionResult UpDateFloor( int id,[FromBody] FloorModel floor)
        { 
           if(floor == null)
                return BadRequest();
            _floorServices.Update(id, floor);
            return NoContent();

        }


    [HttpDelete("{id}")]
        public IActionResult DeleteFloor(int id)
        {
            _floorServices.Delete(id);
            return NoContent();
       
        }



       
       
   }
}

