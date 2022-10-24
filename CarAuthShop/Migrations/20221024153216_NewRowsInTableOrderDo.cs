using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuthShop.Migrations
{
    public partial class NewRowsInTableOrderDo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "OrderDo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "OrderDo");
        }
    }
}
