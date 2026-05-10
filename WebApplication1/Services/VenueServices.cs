using System;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class VenueServices
    {
        private InfrastructureDbContext _db;

        public VenueServices(InfrastructureDbContext db)
        { _db = db; }



        public List<VenueDto> GetAllVenues()
        {
            return _db.Venues.Where(l => l.Status != RowStatus.Deleted).Select(l => new VenueDto { id=l.Id,name=l.Name}).ToList();
        }


        public VenueDto Get(int id)
        {
            return _db.Venues.Where(l => l.Id == id && l.Status != RowStatus.Deleted).Select(l => new VenueDto { id = l.Id, name = l.Name }).FirstOrDefault();
        }




        public VenueDto CreateVenue(VenueModel model)
        {
            var newVenue = new Venue
            {
               Name = model.Name,


            };
            _db.Venues.Add(newVenue);
            _db.SaveChanges();

            return new VenueDto {id=newVenue.Id,name=newVenue.Name};
        }




        public void UpDateVenue(int id, VenueModel model)
        {
            var exisVenue = _db.Venues.Where(l => l.Status != RowStatus.Deleted).FirstOrDefault(l => l.Id == id);
            if (exisVenue != null)
            {
                exisVenue.Name =model.Name; ;
                exisVenue.Status = RowStatus.Updated;
                _db.SaveChanges();
            }


        }
        public void DEleteVenue(int id)
        {
            var venue = _db.Venues.Find(id);
            if (venue != null)
            {
                venue.Status = RowStatus.Deleted;
                _db.SaveChanges();


            }


        }



    }
}
