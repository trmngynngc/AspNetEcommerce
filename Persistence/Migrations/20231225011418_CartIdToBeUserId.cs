using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CartIdToBeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Carts_CartId",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "CartUserId",
                table: "CartDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartUserId",
                table: "CartDetails",
                column: "CartUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Carts_CartUserId",
                table: "CartDetails",
                column: "CartUserId",
                principalTable: "Carts",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Carts_CartUserId",
                table: "CartDetails");

            migrationBuilder.DropIndex(
                name: "IX_CartDetails_CartUserId",
                table: "CartDetails");

            migrationBuilder.DropColumn(
                name: "CartUserId",
                table: "CartDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Carts",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Carts_CartId",
                table: "CartDetails",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
