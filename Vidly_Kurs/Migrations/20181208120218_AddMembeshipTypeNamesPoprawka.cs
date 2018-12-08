using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class AddMembeshipTypeNamesPoprawka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
    table: "MembershipType",
    keyColumn: "Id",
    keyValue: "2",
    column: "Name",
    value: "Miesięczna"
    );
            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "Kwartalna"
                );
            migrationBuilder.UpdateData(
               table: "MembershipType",
               keyColumn: "Id",
               keyValue: "4",
               column: "Name",
               value: "Roczna"
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
