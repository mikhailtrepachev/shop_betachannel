using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuthShop.Migrations
{
    public partial class ChangeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_AspNetUsers_UserDoId",
                table: "CarUser");

            migrationBuilder.DropTable(
                name: "CarDoCarUserDo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarUser");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "CarUser",
                newName: "CarDoId");

            migrationBuilder.AlterColumn<string>(
                name: "UserDoId",
                table: "CarUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LabelAndModel",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CarUser_CarDoId",
                table: "CarUser",
                column: "CarDoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_AspNetUsers_UserDoId",
                table: "CarUser",
                column: "UserDoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_Cars_CarDoId",
                table: "CarUser",
                column: "CarDoId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_AspNetUsers_UserDoId",
                table: "CarUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CarUser_Cars_CarDoId",
                table: "CarUser");

            migrationBuilder.DropIndex(
                name: "IX_CarUser_CarDoId",
                table: "CarUser");

            migrationBuilder.DropColumn(
                name: "LabelAndModel",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CarDoId",
                table: "CarUser",
                newName: "CarId");

            migrationBuilder.AlterColumn<string>(
                name: "UserDoId",
                table: "CarUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CarUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "CarDoCarUserDo",
                columns: table => new
                {
                    CarDosId = table.Column<int>(type: "int", nullable: false),
                    CarUserDoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDoCarUserDo", x => new { x.CarDosId, x.CarUserDoId });
                    table.ForeignKey(
                        name: "FK_CarDoCarUserDo_Cars_CarDosId",
                        column: x => x.CarDosId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDoCarUserDo_CarUser_CarUserDoId",
                        column: x => x.CarUserDoId,
                        principalTable: "CarUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDoCarUserDo_CarUserDoId",
                table: "CarDoCarUserDo",
                column: "CarUserDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarUser_AspNetUsers_UserDoId",
                table: "CarUser",
                column: "UserDoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
