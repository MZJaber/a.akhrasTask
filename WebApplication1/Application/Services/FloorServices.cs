
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    
    public class FloorServices
    {
        private readonly FloorRepository _FloorRepo ;

     


        public FloorServices(FloorRepository FloorRepo)
        { _FloorRepo = FloorRepo; }
        public List<FloorDto> GetAllFloor()
        {
            return _FloorRepo.GetAllFloor().Select(f => new FloorDto(f)).ToList();
        }


        

        public FloorDto GetFloor(int id)
        {

            var f =_FloorRepo.GetFloor(id);

             return   new FloorDto (f);
        }


        public FloorDto Add(FloorModel model)
        {
            var newFloor = new Floor
            {
                Name = model.Name,
                Level = model.Level,
                IsDeleted = false,
                VenueId= model.VenueId,
                Status= RowStatus.New
            
               
            };
            _FloorRepo.Add(newFloor);
           
            return new FloorDto(newFloor);
        }

        public void Update(int id,FloorModel model)
        {
            var exixFloor = _FloorRepo.GetFloor(id);
            if (exixFloor != null) 
            { 
            exixFloor.Name = model.Name;
                exixFloor.Level = model.Level;
                exixFloor.VenueId = model.VenueId;
                exixFloor.Status = RowStatus.New;
                
                _FloorRepo.Update(exixFloor);
            }
            

        }




        public void Delete(int  id)
        {
            var floor = _FloorRepo.GetFloor(id);
            if (floor != null)
            {
                floor.Status = RowStatus.Deleted;

                _FloorRepo.Delete(floor);


            }


        }

       
    
    }
}
