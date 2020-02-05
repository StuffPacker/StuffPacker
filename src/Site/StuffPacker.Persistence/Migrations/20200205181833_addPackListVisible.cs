using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffPacker.Persistence.Migrations
{
    public partial class addPackListVisible : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "PackLists",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "PackLists");
        }
    }
}
