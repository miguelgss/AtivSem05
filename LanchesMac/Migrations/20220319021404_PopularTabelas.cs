using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMac.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
