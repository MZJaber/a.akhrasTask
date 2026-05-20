using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class LineRepository
    {
        private InfrastructureDbContext _db;

        public LineRepository(InfrastructureDbContext db)
        {  _db = db; }


        public List<Line> GetAllLine()
        {

            return _db.Lines.Where(f => f.Status != RowStatus.Deleted).ToList();
        }


        public Line Get(int id) 
            {
            return _db.Lines.Where(l => l.Id == id && l.Status != RowStatus.Deleted).FirstOrDefault();
            }



        public void AddLine(Line line)
        {
            _db.Lines.Add(line);
            _db.SaveChanges();

        }

        public void DeleteLine(Line lineOb) 
        {
            _db.Update(lineOb);
            _db.SaveChanges();

        }


        public void UpdateLine(Line line)
        {
            _db.SaveChanges();
        }





    }
}
