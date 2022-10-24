using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuthShop.Migrations
{
    public partial class NewTableOrderDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarDoId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDo_Cars_CarDoId",
                        column: x => x.CarDoId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDo_CarDoId",
                table: "OrderDo",
                column: "CarDoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDo");
        }
    }
}
