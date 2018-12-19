using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class WypozyczeniaAddDataZwrotu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataZwrotu",
                table: "Wyporzyczenia",
                nullable: false,
                defaultValue: DateTime.Now
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataZwrotu",
                table: "Wyporzyczenia");
        }
    }
}
