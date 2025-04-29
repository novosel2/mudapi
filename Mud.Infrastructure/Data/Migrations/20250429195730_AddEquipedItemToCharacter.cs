using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipedItemToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EquippedItemId",
                table: "Characters",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_EquippedItemId",
                table: "Characters",
                column: "EquippedItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Items_EquippedItemId",
                table: "Characters",
                column: "EquippedItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Items_EquippedItemId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_EquippedItemId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "EquippedItemId",
                table: "Characters");
        }
    }
}
