using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffPacker.Persistence.Migrations
{
    public partial class prefixToList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeightPrefix",
                table: "PackLists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeightPrefix",
                table: "PackLists");
        }
    }
}
