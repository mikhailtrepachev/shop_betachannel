using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuthShop.Migrations
{
    public partial class ChangeSchema3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_Cars_CarDoId",
                table: "CarUser");

            migrationBuilder.DropIndex(
                name: "IX_CarUser_CarDoId",
                table: "CarUser");

            migrationBuilder.AddColumn<int>(
                name: "CarUserDoId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarUserDoId",
                table: "Cars",
                column: "CarUserDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarUser_CarUserDoId",
                table: "Cars",
                column: "CarUserDoId",
                principalTable: "CarUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarUser_CarUserDoId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarUserDoId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarUserDoId",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_CarUser_CarDoId",
                table: "CarUser",
                column: "CarDoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_Cars_CarDoId",
                table: "CarUser",
                column: "CarDoId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
