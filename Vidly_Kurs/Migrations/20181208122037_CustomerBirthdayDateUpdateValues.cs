using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class CustomerBirthdayDateUpdateValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn:"Id",
                keyValue:"1",
                column:"BirthdayDate",
                value: "06/01/1990" 
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
