using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_BranchManager_BranchManagerCode",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_RegionCode_AreaCode",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "BranchManagerCode",
                table: "Branch",
                newName: "BranchManagerId");

            migrationBuilder.RenameColumn(
                name: "AreaCode",
                table: "Branch",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_BranchManagerCode",
                table: "Branch",
                newName: "IX_Branch_BranchManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_AreaCode",
                table: "Branch",
                newName: "IX_Branch_AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_DegreeId",
                table: "Branch",
                column: "DegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Bank_BankId",
                table: "Branch",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_BranchManager_BranchManagerId",
                table: "Branch",
                column: "BranchManagerId",
                principalTable: "BranchManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Degree_DegreeId",
                table: "Branch",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_RegionCode_AreaId",
                table: "Branch",
                column: "AreaId",
                principalTable: "RegionCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Bank_BankId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_BranchManager_BranchManagerId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Degree_DegreeId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_RegionCode_AreaId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_DegreeId",
                table: "Branch");

            migrationBuilder.RenameColumn(
                name: "BranchManagerId",
                table: "Branch",
                newName: "BranchManagerCode");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Branch",
                newName: "AreaCode");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_BranchManagerId",
                table: "Branch",
                newName: "IX_Branch_BranchManagerCode");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_AreaId",
                table: "Branch",
                newName: "IX_Branch_AreaCode");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_BranchManager_BranchManagerCode",
                table: "Branch",
                column: "BranchManagerCode",
                principalTable: "BranchManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_RegionCode_AreaCode",
                table: "Branch",
                column: "AreaCode",
                principalTable: "RegionCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
