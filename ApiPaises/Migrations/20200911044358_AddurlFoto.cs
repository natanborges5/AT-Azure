using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPaises.Migrations
{
    public partial class AddurlFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlFoto",
                table: "Paises",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urlFoto",
                table: "Paises");
        }
    }
}
