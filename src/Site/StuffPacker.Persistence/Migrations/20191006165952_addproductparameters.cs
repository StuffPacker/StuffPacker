using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffPacker.Persistence.Migrations
{
    public partial class addproductparameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Consumables",
                table: "PersonalizedProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Star",
                table: "PersonalizedProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Wearable",
                table: "PersonalizedProducts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Consumables",
                table: "PersonalizedProducts");

            migrationBuilder.DropColumn(
                name: "Star",
                table: "PersonalizedProducts");

            migrationBuilder.DropColumn(
                name: "Wearable",
                table: "PersonalizedProducts");
        }
    }
}
