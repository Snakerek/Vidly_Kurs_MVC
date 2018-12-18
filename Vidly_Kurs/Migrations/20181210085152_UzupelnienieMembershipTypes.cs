using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class UzupelnienieMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new string[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate", "Name" },
                values: new string[] { "2", "30", "1", "10", "Miesięczna" }
            );
            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new string[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate", "Name" },
                values: new string[] { "3", "90", "3", "15", "Kwartalna" }
            );
            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new string[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate", "Name" },
                values: new string[] { "4", "300", "12", "20", "Roczna" }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new string[] { "Id", "Name", "IsSubscribedToNewsletter", "MembershipTypeId", "BirthdayDate" },
                values: new Object[] { "1", "Kacper Z", false, "1", "1990-01-06" }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new string[] { "Id", "Name", "IsSubscribedToNewsletter", "MembershipTypeId", "BirthdayDate" },
                values: new Object[] { "2", "Marry K", true, "3", "1985-02-04" }
            );
            */
        }
    
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
