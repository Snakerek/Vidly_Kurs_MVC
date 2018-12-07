using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly_Kurs.Migrations
{
    public partial class AddIsSubscribedToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_CustomerId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribedToNewsletter",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribedToNewsletter",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
