using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticeAspNetCoreWithKunvenkat.Migrations
{
    public partial class seedEmployeeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "Tedu@abv.bg", "Tedu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "radu@abv.bg", "Radu" });
        }
    }
}
