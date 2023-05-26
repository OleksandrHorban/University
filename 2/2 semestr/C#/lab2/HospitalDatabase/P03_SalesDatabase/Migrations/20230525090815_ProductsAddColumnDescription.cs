using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P03_SalesDatabase.Migrations
{
    /// <inheritdoc />
    public partial class ProductsAddColumnDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    CreditCardNumber = table.Column<string>(type: "varchar(50)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, defaultValue: "No description")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreditCardNumber", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "3529-5634-1268-8411", "Myrtice.Wunsch@yahoo.com", "Olin" },
                    { 2, "6767-9464-3497-6305-37", "Flavie92@yahoo.com", "Hobart" },
                    { 3, "6771-8915-1296-3634", "Elody.Conn38@hotmail.com", "Cary" },
                    { 4, "6382-6301-4060-4355", "Michale.Walsh@hotmail.com", "Brain" },
                    { 5, "6759-2645-4336-8809", "Elsa.McKenzie@gmail.com", "Connie" },
                    { 6, "6767-8512-6773-8870-30", "Cathryn_Klocko@gmail.com", "Aaliyah" },
                    { 7, "3529-2611-3383-6142", "Priscilla_Kerluke@hotmail.com", "Rylan" },
                    { 8, "3417-418840-29262", "Jayme_Little@gmail.com", "Noble" },
                    { 9, "6011-7339-0559-6508", "Shanny.Cremin@hotmail.com", "Kaycee" },
                    { 10, "4207876597490", "Berniece51@gmail.com", "Marion" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Refined Granite Keyboard", 2820m, 1m },
                    { 2, "Ergonomic Soft Towels", 2013m, 4m },
                    { 3, "Tasty Plastic Hat", 483m, 6m },
                    { 4, "Generic Concrete Keyboard", 916m, 7m },
                    { 5, "Awesome Fresh Towels", 1074m, 4m },
                    { 6, "Incredible Plastic Fish", 918m, 10m },
                    { 7, "Small Steel Shirt", 2992m, 8m },
                    { 8, "Unbranded Steel Car", 2160m, 2m },
                    { 9, "Sleek Frozen Chips", 2444m, 8m },
                    { 10, "Ergonomic Metal Cheese", 2858m, 2m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Name" },
                values: new object[,]
                {
                    { 1, "Conroy Inc" },
                    { 2, "Ledner, Mayert and Fahey" },
                    { 3, "Hand, Yost and Parker" },
                    { 4, "Turner, Kovacek and Zboncak" },
                    { 5, "Feest - Smith" },
                    { 6, "Zboncak, Armstrong and Wyman" },
                    { 7, "Marvin, Schultz and Flatley" },
                    { 8, "Volkman Group" },
                    { 9, "Fadel Group" },
                    { 10, "Will, Hermiston and Adams" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "CustomerId", "Date", "ProductId", "StoreId" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2022, 6, 24, 8, 3, 53, 634, DateTimeKind.Local).AddTicks(1075), 1, 10 },
                    { 2, 7, new DateTime(2023, 2, 25, 8, 56, 18, 630, DateTimeKind.Local).AddTicks(1077), 4, 4 },
                    { 3, 5, new DateTime(2023, 3, 4, 17, 13, 55, 877, DateTimeKind.Local).AddTicks(326), 7, 9 },
                    { 4, 8, new DateTime(2023, 3, 12, 16, 1, 34, 573, DateTimeKind.Local).AddTicks(3908), 10, 3 },
                    { 5, 2, new DateTime(2022, 10, 18, 16, 21, 54, 649, DateTimeKind.Local).AddTicks(1374), 7, 7 },
                    { 6, 5, new DateTime(2023, 1, 2, 15, 32, 21, 143, DateTimeKind.Local).AddTicks(8843), 2, 1 },
                    { 7, 1, new DateTime(2023, 4, 30, 4, 54, 17, 432, DateTimeKind.Local).AddTicks(9453), 10, 8 },
                    { 8, 8, new DateTime(2022, 8, 29, 17, 30, 3, 179, DateTimeKind.Local).AddTicks(7844), 8, 10 },
                    { 9, 9, new DateTime(2022, 10, 2, 0, 11, 30, 455, DateTimeKind.Local).AddTicks(8002), 7, 3 },
                    { 10, 7, new DateTime(2023, 3, 15, 15, 6, 47, 695, DateTimeKind.Local).AddTicks(11), 7, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StoreId",
                table: "Sales",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
