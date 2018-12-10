using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Vidly_Kurs.Migrations
{
    public partial class WypelnienieListyFilmow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new string[] { "Name","GatunekId","DataWydania","DataDodaniaDoKatalogu","IloscDostepnychKopi" },
                values: new Object[] { "Władca Pierścieni - Drużyna Pierścienia",1, "2001-12-10","2018-12-10",5 });
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new string[] { "Name", "GatunekId", "DataWydania", "DataDodaniaDoKatalogu", "IloscDostepnychKopi" },
                values: new Object[] { "Władca Pierścieni - Dwie Wieże", 1, "2002-12-05", "2018-12-10", 7 });
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new string[] { "Name", "GatunekId", "DataWydania", "DataDodaniaDoKatalogu", "IloscDostepnychKopi" },
                values: new Object[] { "Władca Pierścieni - Powrót Króla", 1, "2003-12-01", "2018-12-10", 2 });
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new string[] { "Name", "GatunekId", "DataWydania", "DataDodaniaDoKatalogu", "IloscDostepnychKopi" },
                values: new Object[] { "Władca Pierścieni - Drużyna Pierścienia", 1, "2001-12-10", "2018-12-10", 5 });
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new string[] { "Name", "GatunekId", "DataWydania", "DataDodaniaDoKatalogu", "IloscDostepnychKopi" },
                values: new Object[] { "Matrix", 2, "1999-03-24", "2018-12-10", 5 });
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new string[] { "Name", "GatunekId", "DataWydania", "DataDodaniaDoKatalogu", "IloscDostepnychKopi" },
                values: new Object[] { "Shrek", 3, "2001-04-22", "2018-12-10", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
