using APIW.Movies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIW.Movies.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //Todos los DBSets de las entidades o modelos

        public DbSet<Category> Categories { get; set; }
    }
}