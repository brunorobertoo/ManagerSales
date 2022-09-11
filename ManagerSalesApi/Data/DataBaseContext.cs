using ManagerSalesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerSalesApi.Data
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }

    }
}
