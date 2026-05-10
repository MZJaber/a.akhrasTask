using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class LineServices
    {
        private InfrastructureDbContext _db;


        public LineServices(InfrastructureDbContext db)
        {
            _db = db;
        }

        public List<LineDto> GetAllLine()
        {
            return _db.Lines.Where(l => l.Status != RowStatus.Deleted).Select(l => new LineDto { first_node_id=l.FirstNodeId,second_node_id=l.SecondNodeId,is_two_way=l.IsTwoWay }).ToList();
        }


        public LineDto Get(int id)
        {
            return _db.Lines.Where(l => l.Id == id && l.Status != RowStatus.Deleted).Select(l => new LineDto { first_node_id = l.FirstNodeId, second_node_id = l.SecondNodeId, is_two_way = l.IsTwoWay }).FirstOrDefault();
        }




        public LineDto AddLine(LineModel model)
        {
            var newline = new Line
            {
               FirstNodeId = model.FirstNodeId,
               SecondNodeId = model.SecondNodeId,
               IsTwoWay = model.IsTwoWay,

            };
            _db.Lines.Add(newline);
            _db.SaveChanges();

            return new LineDto { id=newline.Id,first_node_id=newline.FirstNodeId,second_node_id=newline.SecondNodeId,is_two_way=newline.IsTwoWay };
        }




        public void UpdateLine(int id, LineModel model)
        {
            var exixLine = _db.Lines.Where(l => l.Status != RowStatus.Deleted).FirstOrDefault(l => l.Id == id);
            if (exixLine != null)
            {
                exixLine.FirstNodeId = model.FirstNodeId;
                exixLine.SecondNodeId = model.SecondNodeId;
                exixLine.IsTwoWay = model.IsTwoWay;
                _db.SaveChanges();
            }


        }
        public void DeleteLine(int id)
        {
            var line = _db.Lines.Find(id);
            if (line != null)
            {
                line.Status = RowStatus.Deleted;
                _db.SaveChanges();


            }


        }




    }


}
