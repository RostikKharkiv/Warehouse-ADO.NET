using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse
{
    class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WarehouseD;Username=postgres;Password=(Тут был мой пароль, ну я на всякий удалил:) можешь свой вставить всё будет работать)");
        }
    }
}
