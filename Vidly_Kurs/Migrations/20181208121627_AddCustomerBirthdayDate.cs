using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class AddCustomerBirthdayDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthdayDate",
                table: "Customers",
                nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthdayDate",
                table: "Customers");
        }
    }
}
