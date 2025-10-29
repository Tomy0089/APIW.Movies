using APIW.Movies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIW.Movies.DAL
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        //Todos los DBSets de las entidades o modelos

        public DbSet<Category> Categories { get; set; }
    }
}