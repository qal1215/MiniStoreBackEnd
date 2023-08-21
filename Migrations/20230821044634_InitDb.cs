using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkshiftsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshiftsType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshiftsType_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemainingProducts = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalItems = table.Column<long>(type: "bigint", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPrice = table.Column<double>(type: "float", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_SalerId",
                        column: x => x.SalerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    PayslipId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonuses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.PayslipId);
                    table.ForeignKey(
                        name: "FK_Payslips_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkshiftTypeId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    IsSunday = table.Column<bool>(type: "bit", nullable: false),
                    CoefficientsSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayslipId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShifts_ApprovalStatuses_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Payslips_PayslipId",
                        column: x => x.PayslipId,
                        principalTable: "Payslips",
                        principalColumn: "PayslipId");
                    table.ForeignKey(
                        name: "FK_WorkShifts_WorkshiftsType_WorkshiftTypeId",
                        column: x => x.WorkshiftTypeId,
                        principalTable: "WorkshiftsType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CheckinCheckouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageCheckin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageCheckout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkShiftId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckinCheckouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckinCheckouts_WorkShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApprovalStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approve" },
                    { 3, "Reject" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Home and Kitchen" },
                    { 4, "Books" },
                    { 5, "Beauty and Personal Care" },
                    { 6, "Meat" },
                    { 7, "Soft drinks" },
                    { 8, "Pork" },
                    { 9, "Toys" },
                    { 10, "Fruits" },
                    { 11, "Vegetables" },
                    { 12, "Dairy Products" },
                    { 13, "Bakery" },
                    { 14, "Meat and Poultry" },
                    { 15, "Frozen Foods" },
                    { 16, "Snacks" },
                    { 17, "Beverages" },
                    { 18, "Canned Goods" },
                    { 19, "Personal Care" },
                    { 20, "Pork" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Guard" },
                    { 3, "Saler" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreateDate", "Email", "FullName", "ImgUrl", "IsActive", "Password", "PositionId" },
                values: new object[,]
                {
                    { "06369936", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(667), "vana@gmail.com", "Nguyen Van A", null, true, "abc123456", 1 },
                    { "31325107", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(811), "thin@gmail.com", "Nguyen Thi N", null, true, "asd123456", 3 },
                    { "67934083", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(755), "vanb@gmail.com", "Nguyen Van B", null, true, "123456", 2 },
                    { "72985534", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(776), "vanc@gmail.com", "Pham Van C", null, true, "asd123456", 3 },
                    { "82365820", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(794), "thid@gmail.com", "Le Thi D", null, true, "asd123456", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Stock", "Unit" },
                values: new object[,]
                {
                    { "product11", 1, "Fresh juicy orange", "orange.jpg", "Orange", 15000m, 110L, "pieces" },
                    { "product12", 1, "Sweet seedless grapes", "grapes.jpg", "Grapes", 30000m, 78L, "pounds" },
                    { "product13", 2, "Greek yogurt", "yogurt.jpg", "Yogurt", 25000m, 60L, "cups" },
                    { "product14", 2, "French baguette", "baguette.jpg", "Baguette", 20000m, 90L, "pieces" },
                    { "product15", 3, "Lean ground beef", "beef.jpg", "Beef", 70000m, 40L, "pounds" },
                    { "product16", 3, "Spaghetti pasta", "pasta.jpg", "Pasta", 30000m, 120L, "pounds" },
                    { "product17", 4, "Chocolate chip cookies", "cookies.jpg", "Cookies", 50000m, 179L, "packs" },
                    { "product18", 4, "Carbonated soft drink", "soda.jpg", "Soda", 20000m, 240L, "cans" },
                    { "product19", 5, "Mint-flavored toothpaste", "toothpaste.jpg", "Toothpaste", 5000m, 100L, "tubes" },
                    { "product20", 5, "Hair conditioner", "conditioner.jpg", "Conditioner", 7000m, 120L, "bottles" },
                    { "product21", 1, "Fresh green lettuce", "lettuce.jpg", "Lettuce", 8000m, 90L, "pieces" },
                    { "product22", 1, "Sweet blueberries", "blueberries.jpg", "Blueberries", 45000m, 60L, "pints" },
                    { "product23", 2, "Cheddar cheese", "cheese.jpg", "Cheese", 55000m, 50L, "pounds" },
                    { "product24", 2, "Plain bagels", "bagels.jpg", "Bagels", 25000m, 100L, "pieces" },
                    { "product25", 3, "Fresh salmon fillet", "salmon.jpg", "Salmon", 899000m, 20L, "pounds" },
                    { "product26", 1, "Sweet tropical pineapple", "pineapple.jpg", "Pineapple", 30000m, 70L, "pieces" },
                    { "product27", 1, "Juicy red strawberries", "strawberries.jpg", "Strawberries", 40000m, 50L, "pints" },
                    { "product28", 2, "Fresh cow milk", "milk.jpg", "Milk", 20000m, 30L, "liters" },
                    { "product29", 2, "Farm-fresh eggs", "eggs.jpg", "Eggs", 15000m, 100L, "dozens" },
                    { "product30", 3, "Lean pork chops", "pork.jpg", "Pork", 55000m, 35L, "pounds" },
                    { "product31", 1, "Fresh orange carrots", "carrots.jpg", "Carrots", 12000m, 90L, "pounds" },
                    { "product32", 1, "Vine-ripened tomatoes", "tomatoes.jpg", "Tomatoes", 18000m, 70L, "pounds" },
                    { "product33", 2, "Creamy butter", "butter.jpg", "Butter", 28000m, 40L, "blocks" },
                    { "product34", 4, "Fruit juice", "juice.jpg", "Juice", 25000m, 60L, "bottles" },
                    { "product35", 5, "Hair shampoo", "shampoo.jpg", "Shampoo", 8500m, 100L, "bottles" }
                });

            migrationBuilder.InsertData(
                table: "WorkshiftsType",
                columns: new[] { "Id", "Name", "PositionId" },
                values: new object[,]
                {
                    { 1, "saler-shift-1", 3 },
                    { 2, "saler-shift-2", 3 },
                    { 3, "saler-shift-3", 3 },
                    { 4, "guard-shift-1", 2 },
                    { 5, "guard-shift-2", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckinCheckouts_WorkShiftId",
                table: "CheckinCheckouts",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalerId",
                table: "Orders",
                column: "SalerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_EmployeeId",
                table: "Payslips",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_ProductId",
                table: "Vouchers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_ApprovalStatusId",
                table: "WorkShifts",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_EmployeeId",
                table: "WorkShifts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_PayslipId",
                table: "WorkShifts",
                column: "PayslipId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_WorkshiftTypeId",
                table: "WorkShifts",
                column: "WorkshiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshiftsType_PositionId",
                table: "WorkshiftsType",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckinCheckouts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ApprovalStatuses");

            migrationBuilder.DropTable(
                name: "Payslips");

            migrationBuilder.DropTable(
                name: "WorkshiftsType");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
