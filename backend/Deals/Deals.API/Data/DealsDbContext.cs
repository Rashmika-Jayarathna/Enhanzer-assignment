using Deals.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.API.Data
{
    public class DealsDbContext : DbContext
    {
        public DealsDbContext(DbContextOptions options) : base(options)
        {
        }

        //DbSet

        public DbSet<Deal> Deals { get; set; }
    }
}
