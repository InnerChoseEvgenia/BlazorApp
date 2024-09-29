using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YumBlazor.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorySet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CategorySet",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizer" },
                    { 2, "Entree" },
                    { 3, "Dessert" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySet");
        }
    }
}
