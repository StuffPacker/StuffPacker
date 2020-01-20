using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffPacker.Persistence.Migrations
{
    public partial class addPackListMaximized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Maximized",
                table: "PackLists",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maximized",
                table: "PackLists");
        }
    }
}
