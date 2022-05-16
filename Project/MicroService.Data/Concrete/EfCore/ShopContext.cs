using Microsoft.EntityFrameworkCore;
using MicroService.Entities;


namespace MicroService.Data.Concrete.EfCore
{
    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =DESKTOP-H7362TJ\SQLEXPRESS; Database=MicroServiceDb; integrated security=true;");
        }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
    }
}
