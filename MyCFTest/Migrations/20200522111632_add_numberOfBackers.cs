using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCFTest.Migrations
{
    public partial class add_numberOfBackers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfBackers",
                table: "Projects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfBackers",
                table: "Projects");
        }
    }
}
