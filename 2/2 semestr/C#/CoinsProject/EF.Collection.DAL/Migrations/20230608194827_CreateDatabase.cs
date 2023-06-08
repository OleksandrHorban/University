using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCollections.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnotherCatalog",
                columns: table => new
                {
                    AnotherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotherCatalog", x => x.AnotherID);
                });

            migrationBuilder.CreateTable(
                name: "BillsCatalog",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    TypeOfSecurity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillsCatalog", x => x.BillID);
                });

            migrationBuilder.CreateTable(
                name: "CoinsCatalog",
                columns: table => new
                {
                    CoinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    Par = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinsCatalog", x => x.CoinId);
                });

            migrationBuilder.InsertData(
                table: "AnotherCatalog",
                columns: new[] { "AnotherID", "Description", "Location", "Name", "Type" },
                values: new object[] { 1, "description of interesting thing from the war", "battlefield in Lviv", "Something another 1", "subject of war" });

            migrationBuilder.InsertData(
                table: "BillsCatalog",
                columns: new[] { "BillID", "Country", "Description", "GraduationYear", "Name", "TypeOfSecurity" },
                values: new object[] { 1, "USA", "Good bill from USA", 1999, "Name of bill 1", "watermark" });

            migrationBuilder.InsertData(
                table: "CoinsCatalog",
                columns: new[] { "CoinId", "Country", "Description", "GraduationYear", "Name", "Par" },
                values: new object[] { 1, "Ukraine", "Good coin with good history", 1980, "Coin Name 1", 10000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnotherCatalog");

            migrationBuilder.DropTable(
                name: "BillsCatalog");

            migrationBuilder.DropTable(
                name: "CoinsCatalog");
        }
    }
}
