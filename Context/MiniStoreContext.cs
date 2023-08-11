using Microsoft.EntityFrameworkCore;
using MiniStore.Models;

namespace MiniStore.Context
{
    public class MiniStoreContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected MiniStoreContext()
        {
        }

        public MiniStoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(c =>
            {
                c.HasNoKey();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
