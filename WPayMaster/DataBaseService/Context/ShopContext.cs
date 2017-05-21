using System.Data.Entity;
using DataBaseService.Model;

namespace DataBaseService.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
            Database.SetInitializer<ShopContext>(null);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Modificator> Modificators { get; set; }
        public DbSet<History> Story { get; set; }
        public IDbSet<Order> Orders { get; set; }
    }
}