using Microsoft.EntityFrameworkCore;
using Inventory_Management_System.Models;
namespace Inventory_Management_System.DataBase
{
    public class Contex : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public Contex(DbContextOptions<Contex> dbContextOptions) : base(dbContextOptions) { }


        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Products>().HasKey("Id_Product");
            builder.Entity<Inventory>().HasKey("Id_Inventory");

        }
    }
}
