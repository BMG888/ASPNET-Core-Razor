using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNET_Core_Proyecto.Migrations
{
    public partial class AddISBM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ISBM",
                table: "Libro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISBM",
                table: "Libro");
        }
    }
}
