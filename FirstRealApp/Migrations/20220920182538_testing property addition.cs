using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstRealApp.Migrations
{
    public partial class testingpropertyaddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PedigreeNumber",
                table: "Poodles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Poodles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PedigreeNumber", "Sex" },
                values: new object[] { "JR 70310tp", "Male" });

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PedigreeNumber", "Sex" },
                values: new object[] { "JR 78838", "Female" });

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PedigreeNumber", "Sex" },
                values: new object[] { "JR 70296tp", "Female" });

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PedigreeNumber", "Sex" },
                values: new object[] { "JR 78837", "Female" });

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PedigreeNumber", "Sex" },
                values: new object[] { "JR 82652", "Female" });

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PedigreeNumber", "Sex" },
                values: new object[] { "JR 78844", "Female" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Poodles");

            migrationBuilder.AlterColumn<string>(
                name: "PedigreeNumber",
                table: "Poodles",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PedigreeNumber",
                value: "JR 70883");

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PedigreeNumber",
                value: "JR 70883");

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PedigreeNumber",
                value: "JR 70883");

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 4,
                column: "PedigreeNumber",
                value: "JR 70883");

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 5,
                column: "PedigreeNumber",
                value: "JR 70883");

            migrationBuilder.UpdateData(
                table: "Poodles",
                keyColumn: "Id",
                keyValue: 6,
                column: "PedigreeNumber",
                value: "JR 81231");
        }
    }
}
