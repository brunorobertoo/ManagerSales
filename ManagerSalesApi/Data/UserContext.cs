using ManagerSalesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerSalesApi.Data
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
