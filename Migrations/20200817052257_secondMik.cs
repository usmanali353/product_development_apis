using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class secondMik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_requests_surfaceId",
                table: "requests");

            migrationBuilder.CreateIndex(
                name: "IX_requests_surfaceId",
                table: "requests",
                column: "surfaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_requests_surfaceId",
                table: "requests");

            migrationBuilder.CreateIndex(
                name: "IX_requests_surfaceId",
                table: "requests",
                column: "surfaceId",
                unique: true);
        }
    }
}
