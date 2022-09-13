using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class portfoliomigrationadjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_customer_CustomerId",
                table: "portfolio");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "portfolio",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_CustomerId",
                table: "portfolio",
                newName: "IX_portfolio_customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_customer_customerId",
                table: "portfolio",
                column: "customerId",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_customer_customerId",
                table: "portfolio");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "portfolio",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_customerId",
                table: "portfolio",
                newName: "IX_portfolio_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_customer_CustomerId",
                table: "portfolio",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
