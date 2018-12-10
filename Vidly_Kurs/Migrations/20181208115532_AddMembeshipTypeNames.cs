﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class AddMembeshipTypeNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Miesięczna");
            /*
            migrationBuilder.InsertData(
            table: "MembershipType",
            columns:new string[] {"Id", "SignUpFee", "DurationInMonths", "DiscountRate", "Name" },
             values: new string[] {"1", "0", "0", "0", "Opłata na żądanie" }
            );
            */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
