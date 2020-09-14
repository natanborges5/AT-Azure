using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPaises.Migrations
{
    public partial class estadoPaisId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "paisId",
                table: "Estados",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paisId",
                table: "Estados");
        }
    }
}
