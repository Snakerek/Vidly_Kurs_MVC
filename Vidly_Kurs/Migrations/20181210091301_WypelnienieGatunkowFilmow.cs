using System;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class WypelnienieGatunkowFilmow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gatunek",
                columns: new string[] {"Name"},
                values: new Object[] {"Fantasy"});
            migrationBuilder.InsertData(
                table: "Gatunek",
                columns: new string[] {"Name" },
                values: new Object[] {"Science-Fiction" });
            migrationBuilder.InsertData(
                table: "Gatunek",
                columns: new string[] {"Name" },
                values: new Object[] {"Animacja" });
            migrationBuilder.InsertData(
                table: "Gatunek",
                columns: new string[] {"Name" },
                values: new Object[] {"Komedia" });
            migrationBuilder.InsertData(
                table: "Gatunek",
                columns: new string[] {"Name" },
                values: new Object[] {"Sensacyjny" });
            migrationBuilder.InsertData(
                table: "Gatunek",
                columns: new string[] {"Name" },
                values: new Object[] {"Familijny" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
