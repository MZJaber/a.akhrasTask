using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class VenueRepository
    {
        private InfrastructureDbContext _db;

        public VenueRepository(InfrastructureDbContext db)
        {_db = db; }




        public List<Venue> GetAllVenues()
        {
            return _db.Venues.Where(l => l.Status != RowStatus.Deleted).ToList();

        }


        public Venue get(int id)
        {

            return _db.Venues.Where(l => l.Id == id && l.Status != RowStatus.Deleted).FirstOrDefault();
        }


        public async Task<Venue> GetVenueAsync(int id)
        {
            return await _db.Venues.Include(l=>l.Floors).Where(l => l.Id == id && l.Status != RowStatus.Deleted).FirstOrDefaultAsync(l=>l.Id==id);
        }


        public void Add(Venue venue)
        {
            _db.Venues.Add(venue);
            _db.SaveChanges();

        }


        public void Update(Venue venue)
        {

            _db.SaveChanges();
        }
        public void Delete(Venue venue)
        {

            _db.Venues.Update(venue);
            _db.SaveChanges();
        }
      







    }
}
