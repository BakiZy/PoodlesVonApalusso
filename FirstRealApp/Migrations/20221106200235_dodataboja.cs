using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstRealApp.Migrations
{
    public partial class dodataboja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PoodleColors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Harelquin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoodleColors",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
