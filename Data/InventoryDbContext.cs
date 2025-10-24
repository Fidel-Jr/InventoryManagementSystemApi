using InventoryMSApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryMSApi.Data
{
    public class InventoryDbContext : DbContext 
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
