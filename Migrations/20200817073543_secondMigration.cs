using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_designersInvolved_designersInvolved_designersInvolvedId1",
                table: "designersInvolved");

            migrationBuilder.DropIndex(
                name: "IX_designersInvolved_designersInvolvedId1",
                table: "designersInvolved");

            migrationBuilder.DropColumn(
                name: "designersInvolvedId1",
                table: "designersInvolved");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "designersInvolvedId1",
                table: "designersInvolved",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_designersInvolved_designersInvolvedId1",
                table: "designersInvolved",
                column: "designersInvolvedId1");

            migrationBuilder.AddForeignKey(
                name: "FK_designersInvolved_designersInvolved_designersInvolvedId1",
                table: "designersInvolved",
                column: "designersInvolvedId1",
                principalTable: "designersInvolved",
                principalColumn: "designersInvolvedId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
