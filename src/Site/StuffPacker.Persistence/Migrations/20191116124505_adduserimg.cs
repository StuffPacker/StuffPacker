using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffPacker.Persistence.Migrations
{
    public partial class adduserimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImgPath",
                table: "UserProfiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImgPath",
                table: "UserProfiles");
        }
    }
}
