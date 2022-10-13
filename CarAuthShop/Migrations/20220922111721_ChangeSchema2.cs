using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuthShop.Migrations
{
    public partial class ChangeSchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_AspNetUsers_UserDoId",
                table: "CarUser");

            migrationBuilder.DropIndex(
                name: "IX_CarUser_UserDoId",
                table: "CarUser");

            migrationBuilder.AlterColumn<string>(
                name: "UserDoId",
                table: "CarUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CarUserDoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CarUserDoId",
                table: "AspNetUsers",
                column: "CarUserDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CarUser_CarUserDoId",
                table: "AspNetUsers",
                column: "CarUserDoId",
                principalTable: "CarUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CarUser_CarUserDoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CarUserDoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CarUserDoId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserDoId",
                table: "CarUser",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_CarUser_UserDoId",
                table: "CarUser",
                column: "UserDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_AspNetUsers_UserDoId",
                table: "CarUser",
                column: "UserDoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
