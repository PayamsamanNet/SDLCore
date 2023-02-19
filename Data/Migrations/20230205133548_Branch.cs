using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Branch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_RegionCode_AreaId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "ForeignNatioanlID",
                table: "ForeignCustomer");

            migrationBuilder.DropColumn(
                name: "FromBranchId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Branch",
                newName: "RegionCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_AreaId",
                table: "Branch",
                newName: "IX_Branch_RegionCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerType_BankId",
                table: "CustomerType",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_RegionCode_RegionCodeId",
                table: "Branch",
                column: "RegionCodeId",
                principalTable: "RegionCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerType_Bank_BankId",
                table: "CustomerType",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_RegionCode_RegionCodeId",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerType_Bank_BankId",
                table: "CustomerType");

            migrationBuilder.DropIndex(
                name: "IX_CustomerType_BankId",
                table: "CustomerType");

            migrationBuilder.RenameColumn(
                name: "RegionCodeId",
                table: "Branch",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Branch_RegionCodeId",
                table: "Branch",
                newName: "IX_Branch_AreaId");

            migrationBuilder.AddColumn<Guid>(
                name: "ForeignNatioanlID",
                table: "ForeignCustomer",
                type: "uniqueidentifier",
                maxLength: 12,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FromBranchId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_RegionCode_AreaId",
                table: "Branch",
                column: "AreaId",
                principalTable: "RegionCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
