using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class EditDto1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                table: "Branch",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BankId",
                table: "Branch",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Bank_BankId",
                table: "Branch",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Bank_BankId",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_BankId",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Branch");
        }
    }
}
