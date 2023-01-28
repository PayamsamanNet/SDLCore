using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Branch3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Branch_BankId_DegreeId",
                table: "Branch");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BankId",
                table: "Branch",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Branch_BankId",
                table: "Branch");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BankId_DegreeId",
                table: "Branch",
                columns: new[] { "BankId", "DegreeId" });
        }
    }
}
