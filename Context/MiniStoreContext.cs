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

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Payslip> Payslips { get; set; }

        public DbSet<Workshift> WorkShifts { get; set; }

        public DbSet<WorkshiftType> WorkshiftsType { get; set; }

        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }

        public DbSet<CheckinCheckout> CheckinCheckouts { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }

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

            //modelBuilder.Entity<Payslip>()
            //    .HasOne(p => p.Employee)
            //    .WithOne()
            //    .HasForeignKey<Payslip>(p => p.EmployeeId);

            //modelBuilder.Entity<Payslip>()
            //    .HasMany(p => p.WorkShifts)
            //    .WithOne();

            modelBuilder.Entity<Position>()
                .HasData(
                    new Position { Id = 1, Name = "Manager" },
                    new Position { Id = 2, Name = "Guard" },
                    new Position { Id = 3, Name = "Saler" }
                );

            modelBuilder.Entity<WorkshiftType>()
                .HasData(
                    new WorkshiftType { Id = 1, Name = "saler-shift-1", PositionId = 3 },
                    new WorkshiftType { Id = 2, Name = "saler-shift-2", PositionId = 3 },
                    new WorkshiftType { Id = 3, Name = "saler-shift-3", PositionId = 3 },
                    new WorkshiftType { Id = 4, Name = "guard-shift-1", PositionId = 2 },
                    new WorkshiftType { Id = 5, Name = "guard-shift-2", PositionId = 2 }
                );

            //modelBuilder.Entity<Employee>()
            //    .HasData(
            //        new Employee
            //        {
            //            Id = Ultility.GenerateEightDigitId(),
            //            FullName = "Nguyen Van A",
            //            Email = "vana@gmail.com",
            //            Password = "abc123456",
            //            CreateDate = DateTime.Now,
            //            PositionId = 1,
            //        },
            //        new Employee
            //        {
            //            Id = Ultility.GenerateEightDigitId(),
            //            FullName = "Nguyen Van B",
            //            Email = "vanb@gmail.com",
            //            Password = "123456",
            //            CreateDate = DateTime.Now,
            //            PositionId = 2,
            //        },
            //        new Employee
            //        {
            //            Id = Ultility.GenerateEightDigitId(),
            //            FullName = "Pham Van C",
            //            Email = "vanc@gmail.com",
            //            Password = "asd123456",
            //            CreateDate = DateTime.Now,
            //            PositionId = 3,
            //        },
            //        new Employee
            //        {
            //            Id = Ultility.GenerateEightDigitId(),
            //            FullName = "Le Thi D",
            //            Email = "thid@gmail.com",
            //            Password = "asd123456",
            //            CreateDate = DateTime.Now,
            //            PositionId = 3,
            //        },
            //        new Employee
            //        {
            //            Id = Ultility.GenerateEightDigitId(),
            //            FullName = "Nguyen Thi N",
            //            Email = "thin@gmail.com",
            //            Password = "asd123456",
            //            CreateDate = DateTime.Now,
            //            PositionId = 3,
            //        }
            //    );

            modelBuilder.Entity<ApprovalStatus>()
                .HasData(
                    new ApprovalStatus { Id = 1, Status = "Pending" },
                    new ApprovalStatus { Id = 2, Status = "Approve" },
                    new ApprovalStatus { Id = 3, Status = "Reject" }
                );

            modelBuilder.Entity<OrderStatus>()
                .HasData(
                    new OrderStatus { StatusId = 1, Title = "Processing" },
                    new OrderStatus { StatusId = 2, Title = "Done" }
                );

            modelBuilder.Entity<Category>()
                .HasData(categories);

            modelBuilder.Entity<Product>()
                .HasData(products);


            base.OnModelCreating(modelBuilder);
        }

        List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" },
            new Category { Id = 3, Name = "Home and Kitchen" },
            new Category { Id = 4, Name = "Books" },
            new Category { Id = 5, Name = "Beauty and Personal Care" },
            new Category { Id = 6, Name = "Meat" },
            new Category { Id = 7, Name = "Soft drinks" },
            new Category { Id = 8, Name = "Pork" },
            new Category { Id = 9, Name = "Toys" },
            new Category { Id = 10, Name = "Fruits" },
            new Category { Id = 11, Name = "Vegetables" },
            new Category { Id = 12, Name = "Dairy Products" },
            new Category { Id = 13, Name = "Bakery" },
            new Category { Id = 14, Name = "Meat and Poultry" },
            new Category { Id = 15, Name = "Frozen Foods" },
            new Category { Id = 16, Name = "Snacks" },
            new Category { Id = 17, Name = "Beverages" },
            new Category { Id = 18, Name = "Canned Goods" },
            new Category { Id = 19, Name = "Personal Care" },
            new Category { Id = 20, Name = "Pork" }
        };

        List<Product> products = new List<Product>
        {
            new Product { Id = "product11", Name = "Orange", Description = "Fresh juicy orange", Price = 15000, ImageUrl = "orange.jpg", Unit = "pieces", Stock = 110, CategoryId = 1 },
            new Product { Id = "product12", Name = "Grapes", Description = "Sweet seedless grapes", Price = 30000, ImageUrl = "grapes.jpg", Unit = "pounds", Stock = 78, CategoryId = 1 },
            new Product { Id = "product13", Name = "Yogurt", Description = "Greek yogurt", Price = 25000, ImageUrl = "yogurt.jpg", Unit = "cups", Stock = 60, CategoryId = 2 },
            new Product { Id = "product14", Name = "Baguette", Description = "French baguette", Price = 20000, ImageUrl = "baguette.jpg", Unit = "pieces", Stock = 90, CategoryId = 2 },
            new Product { Id = "product15", Name = "Beef", Description = "Lean ground beef", Price = 70000, ImageUrl = "beef.jpg", Unit = "pounds", Stock = 40, CategoryId = 3 },
            new Product { Id = "product16", Name = "Pasta", Description = "Spaghetti pasta", Price = 30000, ImageUrl = "pasta.jpg", Unit = "pounds", Stock = 120, CategoryId = 3 },
            new Product { Id = "product17", Name = "Cookies", Description = "Chocolate chip cookies", Price = 50000, ImageUrl = "cookies.jpg", Unit = "packs", Stock = 179, CategoryId = 4 },
            new Product { Id = "product18", Name = "Soda", Description = "Carbonated soft drink", Price = 20000, ImageUrl = "soda.jpg", Unit = "cans", Stock = 240, CategoryId = 4 },
            new Product { Id = "product19", Name = "Toothpaste", Description = "Mint-flavored toothpaste", Price = 5000, ImageUrl = "toothpaste.jpg", Unit = "tubes", Stock = 100, CategoryId = 5 },
            new Product { Id = "product20", Name = "Conditioner", Description = "Hair conditioner", Price = 7000, ImageUrl = "conditioner.jpg", Unit = "bottles", Stock = 120, CategoryId = 5 },
            new Product { Id = "product21", Name = "Lettuce", Description = "Fresh green lettuce", Price = 8000, ImageUrl = "lettuce.jpg", Unit = "pieces", Stock = 90, CategoryId = 1 },
            new Product { Id = "product22", Name = "Blueberries", Description = "Sweet blueberries", Price = 45000, ImageUrl = "blueberries.jpg", Unit = "pints", Stock = 60, CategoryId = 1 },
            new Product { Id = "product23", Name = "Cheese", Description = "Cheddar cheese", Price = 55000, ImageUrl = "cheese.jpg", Unit = "pounds", Stock = 50, CategoryId = 2 },
            new Product { Id = "product24", Name = "Bagels", Description = "Plain bagels", Price = 25000, ImageUrl = "bagels.jpg", Unit = "pieces", Stock = 100, CategoryId = 2 },
            new Product { Id = "product25", Name = "Salmon", Description = "Fresh salmon fillet", Price = 899000, ImageUrl = "salmon.jpg", Unit = "pounds", Stock = 20, CategoryId = 3 },
            new Product { Id = "product26", Name = "Pineapple", Description = "Sweet tropical pineapple", Price = 30000, ImageUrl = "pineapple.jpg", Unit = "pieces", Stock = 70, CategoryId = 1 },
            new Product { Id = "product27", Name = "Strawberries", Description = "Juicy red strawberries", Price = 40000, ImageUrl = "strawberries.jpg", Unit = "pints", Stock = 50, CategoryId = 1 },
            new Product { Id = "product28", Name = "Milk", Description = "Fresh cow milk", Price = 20000, ImageUrl = "milk.jpg", Unit = "liters", Stock = 30, CategoryId = 2 },
            new Product { Id = "product29", Name = "Eggs", Description = "Farm-fresh eggs", Price = 15000, ImageUrl = "eggs.jpg", Unit = "dozens", Stock = 100, CategoryId = 2 },
            new Product { Id = "product30", Name = "Pork", Description = "Lean pork chops", Price = 55000, ImageUrl = "pork.jpg", Unit = "pounds", Stock = 35, CategoryId = 3 },
            new Product { Id = "product31", Name = "Carrots", Description = "Fresh orange carrots", Price = 12000, ImageUrl = "carrots.jpg", Unit = "pounds", Stock = 90, CategoryId = 1 },
            new Product { Id = "product32", Name = "Tomatoes", Description = "Vine-ripened tomatoes", Price = 18000, ImageUrl = "tomatoes.jpg", Unit = "pounds", Stock = 70, CategoryId = 1 },
            new Product { Id = "product33", Name = "Butter", Description = "Creamy butter", Price = 28000, ImageUrl = "butter.jpg", Unit = "blocks", Stock = 40, CategoryId = 2 },
            new Product { Id = "product34", Name = "Juice", Description = "Fruit juice", Price = 25000, ImageUrl = "juice.jpg", Unit = "bottles", Stock = 60, CategoryId = 4 },
            new Product { Id = "product35", Name = "Shampoo", Description = "Hair shampoo", Price = 8500, ImageUrl = "shampoo.jpg", Unit = "bottles", Stock = 100, CategoryId = 5 },
        };
    }
}
