using BaseStations.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseStations.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public DbSet<BaseStation> BaseStations { get; set; }
    }
}
