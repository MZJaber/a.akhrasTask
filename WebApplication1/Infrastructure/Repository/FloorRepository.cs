using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class FloorRepository
    {
        private InfrastructureDbContext _db;


        public FloorRepository(InfrastructureDbContext db)
        {
            _db = db;
        }



        public List<Floor> GetAllFloor()
        {
            return _db.Floors.Where(f => f.Status != RowStatus.Deleted).ToList();
        }




        public Floor GetFloor(int id)
        {

            return _db.Floors.Where(f => f.Id == id && f.Status != RowStatus.Deleted).FirstOrDefault();


        }

        public List<Floor> GetFloorId(int id)
        {
            return _db.Floors.Where(f => f.VenueId == id && f.Status != RowStatus.Deleted).ToList();
        }



        public void Add(Floor floor) 
            {
            _db.Floors.Add(floor);
            _db.SaveChanges(); ;
            }



        public void Update(Floor floor) 
        {
           
            _db.SaveChanges();
        }

        public void Delete(Floor floorOb) 
            {

            _db.Floors.Update(floorOb);
            _db.SaveChanges();

        }




    }
}
