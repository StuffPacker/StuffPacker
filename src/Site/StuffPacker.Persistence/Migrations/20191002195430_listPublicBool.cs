using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffPacker.Persistence.Migrations
{
    public partial class listPublicBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "PackLists",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "PackLists");
        }
    }
}
