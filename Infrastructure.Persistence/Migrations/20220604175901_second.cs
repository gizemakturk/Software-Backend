using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GearType",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "NumberOfSeat",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelYear",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModelYear",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "GearType",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeat",
                table: "Cars",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
