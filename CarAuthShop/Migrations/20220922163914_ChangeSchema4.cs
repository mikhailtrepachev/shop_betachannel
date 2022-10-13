using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuthShop.Migrations
{
    public partial class ChangeSchema4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages");

            migrationBuilder.AddColumn<int>(
                name: "CarDoId",
                table: "CarImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarDoId",
                table: "CarImages",
                column: "CarDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Cars_CarDoId",
                table: "CarImages",
                column: "CarDoId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarImages_Cars_CarDoId",
                table: "CarImages");

            migrationBuilder.DropIndex(
                name: "IX_CarImages_CarDoId",
                table: "CarImages");

            migrationBuilder.DropColumn(
                name: "CarDoId",
                table: "CarImages");

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarImages_Cars_CarId",
                table: "CarImages",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
