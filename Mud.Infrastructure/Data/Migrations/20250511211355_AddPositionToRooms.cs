using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionToRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PosX",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosY",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Rooms");
        }
    }
}
