using Microsoft.EntityFrameworkCore;
using Inventory_Management_System.Models;
namespace Inventory_Management_System.DataBase
{
    public class Context : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<CreateUser> User { get; set; }
        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { }


        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Products>().HasKey("Id_Product");
            builder.Entity<Inventory>().HasKey("Id_Inventory");

        }
    }
}
