using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq.Expressions;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  public class venuesController : ControllerBase
    {

   [HttpGet]
        public IActionResult GetAllVenues()
        {

            var vdb = new InfrastructureDbContext();
            var venues = vdb.Venues.Where(f => f.Status != RowStatus.Deleted).ToList();

            // Return all products
            return Ok(venues);
        }




   [HttpGet("{id}")]
        public ActionResult<Venue> Get(int id)
        {
            var vedb = new InfrastructureDbContext();
            var venueId = vedb.Venues.FirstOrDefault(v => v.Id == id && v.Status != RowStatus.Deleted);
            if (venueId == null)
            {
                return NotFound();
            }
            return venueId;
        }


   [HttpPost]

        public IActionResult CreateVenue([FromBody] VenueModel Venue )
        {
            if (Venue == null) 
                return BadRequest();    

            var Vendb=new InfrastructureDbContext();
            var NewVenuw = new Venue()
            {
                Name = Venue.Name,
                IsDeleted = false,
            };

            Vendb.Venues.Add(NewVenuw);
            Vendb.SaveChanges();
            return Ok(new {id=NewVenuw.Id});
        }

     


   [HttpPut("{id}")]

        public IActionResult UpDateVenue([FromBody] VenueModel venue)
        {
            if (venue == null)
                return BadRequest();

            var venudb=new InfrastructureDbContext();
            var exisVenue= venudb.Venues.Where(v => v.Status != RowStatus.Deleted).FirstOrDefault(v => v.Id == venue.Id);

            if (exisVenue == null)
                return NotFound();

            exisVenue.Name = venue.Name;
            exisVenue.Status = RowStatus.Updated;
            venudb.SaveChanges();

            return Ok();



        }



   [HttpDelete("{id}")]
        public IActionResult DEleteVenue(int id)
        { 
        var venuedb=new InfrastructureDbContext();
        var exixvenue= venuedb.Venues.Where(v => v.Status != RowStatus.Deleted).FirstOrDefault(v =>v.Id == id);

            if(exixvenue == null)
                return NotFound();

            exixvenue.IsDeleted = true;
            exixvenue.Status = RowStatus.Deleted;
            venuedb.SaveChanges();
            return Ok();
               
        }

        public class VenueModel
        {
            public int Id { get; set; }

            public string? Name { get; set; }
        }



  }
   
}
