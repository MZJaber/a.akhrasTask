using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class floorController : Controller
   {

    [HttpGet]
        public IActionResult GetAllFloor()
        {
            var flodb = new InfrastructureDbContext();
            var Floors = flodb.Floors.Where(f => f.Status != RowStatus.Deleted).Select(f => new FloorDto { id=f.Id,Name=f.Name,Level= f.Level,VenueId=f.VenueId});

            return Ok( Floors);
        }
        

    [HttpGet("{id}")]
        public ActionResult<Floor> GetFloor(int id)
        {
            var fdb = new InfrastructureDbContext();
            var floor = fdb.Floors.Where(f => f.Id == id && f.Status != RowStatus.Deleted).Select(f => new FloorDto { id = f.Id, Name = f.Name, Level = f.Level,VenueId=f.VenueId }).FirstOrDefault();
            if (floor == null)
            {
                return NotFound();

            }
            return Ok(floor);
        }






    [HttpPost]
       public IActionResult CreateFloor([FromBody] FloorModel floor)
       {
            if (floor == null)
                return BadRequest();

            var flodb = new InfrastructureDbContext();

            var newFloor = new Floor()
            {
                Name = floor.Name,
                VenueId = floor.VenueId ?? 0,
                Level = floor.Level,
                IsDeleted = false
            };

            flodb.Floors.Add(newFloor);
            flodb.SaveChanges();

            return Ok(new { id = newFloor.Id });
       }
      



    [HttpPut("{id}")]

        public IActionResult UpDateFloor( int id,[FromBody] FloorModel floor)
        { 
           if(floor == null)
                return BadRequest();
           var flodb = new InfrastructureDbContext();
           var exixFloor= flodb.Floors.Where(f => f.Status != RowStatus.Deleted).FirstOrDefault(f => f.Id == id);

            if (exixFloor == null)   
                return NotFound();

            //exixFloor.Id = (int)floor.Id;
            exixFloor.Name = floor.Name;
            exixFloor.Level = floor.Level;
            exixFloor.VenueId= floor.VenueId;
            exixFloor.Status = RowStatus.Updated;

            flodb.SaveChanges();

            return Ok();

        }


    [HttpDelete("{id}")]
        public IActionResult DeleteFloor(int id)
        { 
        var flodb= new InfrastructureDbContext();
        var exixFlor= flodb.Floors.Where(f=> f.Status != RowStatus.Deleted).FirstOrDefault(f => f.Id == id);

            if (exixFlor == null)
                return NotFound();
            exixFlor.IsDeleted= true;
            exixFlor.Status= RowStatus.Deleted;
            flodb.SaveChanges ();
        
        return Ok();
        
        }



        public class FloorModel
        {
        

            public string? Name { get; set; }

            public int? VenueId { get; set; }

            public int? Level { get; set; }
        }

      
    }
}
