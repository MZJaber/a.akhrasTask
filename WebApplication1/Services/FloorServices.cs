
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    
    public class FloorServices
    {
        private readonly InfrastructureDbContext _db ;

     


        public FloorServices(InfrastructureDbContext db)
        {_db = db; }
        public List<FloorDto> GetAllFloor()
        {
            return _db.Floors.Where(f => f.Status != RowStatus.Deleted).Select(f => new FloorDto { id = f.Id, Name = f.Name, Level = f.Level, VenueId = f.VenueId }).ToList();
        }


        

        public FloorDto GetFloor(int id)
        {
            return _db.Floors.Where(f => f.Id == id && f.Status != RowStatus.Deleted).Select(f => new FloorDto { id = f.Id, Name = f.Name, Level = f.Level, VenueId = f.VenueId }).FirstOrDefault();
        }


        public Floor Add(FloorModel model)
        {
            var newFloor = new Floor
            {
                Name = model.Name,
                Level = model.Level,
                IsDeleted = false,
                VenueId= model.VenueId
               
            };
            _db.Floors.Add(newFloor);
            _db.SaveChanges();
            return newFloor;
        }

        public void Update(int id,FloorModel model)
        {
            var exixFloor = _db.Floors.Where(f => f.Status != RowStatus.Deleted).FirstOrDefault(f => f.Id == id);
            if (exixFloor != null) 
            { 
            exixFloor.Name = model.Name;
                exixFloor.Level = model.Level;
                exixFloor.VenueId = model.VenueId;
                _db.SaveChanges();
            }
            

        }




        public void Delete(int  id)
        {
            var floor = _db.Floors.Find(id);
            if (floor != null)
            {
                floor.Status = RowStatus.Deleted;
                _db.SaveChanges();


            }


        }

       
    
    }
}
