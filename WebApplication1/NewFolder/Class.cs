using Microsoft.EntityFrameworkCore;
using WebApplication1.NewFolder.Models;

namespace WebApplication1.NewFolder
{
    public class AppDbCotext: DbContext
    {
        public AppDbCotext() { }
        public AppDbCotext( DbContextOptions<AppDbCotext> option): base(option)
        {

     
        }
        public  DbSet<Category> categories { get; set; }
    }
}
