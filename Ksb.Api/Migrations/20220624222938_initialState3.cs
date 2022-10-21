using Microsoft.EntityFrameworkCore.Migrations;

namespace Ksb.Api.Migrations
{
    public partial class initialState3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Montant",
                table: "Financement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Montant",
                table: "Financement");
        }
    }
}
