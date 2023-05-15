using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBE.Infrastructure.Migrations
{
    public partial class userorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomerUserId",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Orders");
        }
    }
}
