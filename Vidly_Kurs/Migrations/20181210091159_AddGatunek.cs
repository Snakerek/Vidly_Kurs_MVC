using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class AddGatunek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gatunek",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "GatunekId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gatunek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunek", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GatunekId",
                table: "Movies",
                column: "GatunekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Gatunek_GatunekId",
                table: "Movies",
                column: "GatunekId",
                principalTable: "Gatunek",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Gatunek_GatunekId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Gatunek");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GatunekId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GatunekId",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Gatunek",
                table: "Movies",
                nullable: false,
                defaultValue: "");
        }
    }
}
