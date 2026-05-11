using Microsoft.AspNetCore.Http.HttpResults;
using System.Drawing;
using WebApplication1.Dto;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class LineServices
    {
        private readonly LineRepository _LineRepo;

       

        public LineServices(LineRepository LineRepo)
        {
            _LineRepo = LineRepo;
        }

        public List<LineDto> GetAllLine()
        {
            return _LineRepo.GetAllLine().Select(l => new LineDto (l)).ToList();
        }


        public LineDto Get(int id)
        {
            var l = _LineRepo.Get(id);
            return new LineDto (l);
        }




        public LineDto AddLine(LineModel model)
        {
            var newline = new Line
            {
               FirstNodeId = model.FirstNodeId,
               SecondNodeId = model.SecondNodeId,
               IsTwoWay = model.IsTwoWay,

            };

            _LineRepo.AddLine(newline);
            

            return new (newline);
        }




        public void UpdateLine(int id,LineModel model)
        {
            var exixLine = _LineRepo.Get(id);
            if (exixLine != null)
            {
                exixLine.FirstNodeId = model.FirstNodeId;
                exixLine.SecondNodeId = model.SecondNodeId;
                exixLine.IsTwoWay = model.IsTwoWay;
                exixLine.Status = RowStatus.New;

            }


        }
        public void DeleteLine(int id)
        {
            var line = _LineRepo.Get(id);
            if (line != null)
            {
                line.Status = RowStatus.Deleted;

                _LineRepo.DeleteLine(line);

            }


        }




    }


}
