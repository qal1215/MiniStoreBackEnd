using Microsoft.EntityFrameworkCore;
using MiniStore.Models;

namespace MiniStore.Context
{
    public class MiniStoreContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Payslip> Payslips { get; set; }

        public DbSet<WorkShift> WorkShifts { get; set; }

        public DbSet<WorkshiftType> WorkshiftsType { get; set; }

        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }

        protected MiniStoreContext()
        {
        }

        public MiniStoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .ToTable(tb => tb.HasTrigger("UpdateProductQuantity"));

            modelBuilder.Entity<WorkshiftType>()
                .HasData(
                    new WorkshiftType { Id = 1, Name = "saler-shift-1", PositionId = 3 },
                    new WorkshiftType { Id = 2, Name = "saler-shift-2", PositionId = 3 },
                    new WorkshiftType { Id = 3, Name = "saler-shift-3", PositionId = 3 },
                    new WorkshiftType { Id = 4, Name = "guard-shift-1", PositionId = 2 },
                    new WorkshiftType { Id = 5, Name = "guard-shift-2", PositionId = 2 }
                );

            modelBuilder.Entity<ApprovalStatus>()
                .HasData(
                    new ApprovalStatus { Id = 1, Status = "Pending" },
                    new ApprovalStatus { Id = 2, Status = "Approve" },
                    new ApprovalStatus { Id = 3, Status = "Reject" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
