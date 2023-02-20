using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Changecustoer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_WorkAddressId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignCustomer_Customer_ForeignNatioanlID",
                table: "ForeignCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCustomer_Customer_CompanyId",
                table: "LegalCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_RealCustomer_Customer_NationalId",
                table: "RealCustomer");

            migrationBuilder.DropIndex(
                name: "IX_RealCustomer_NationalId",
                table: "RealCustomer");

            migrationBuilder.DropIndex(
                name: "IX_LegalCustomer_CompanyId",
                table: "LegalCustomer");

            migrationBuilder.DropIndex(
                name: "IX_ForeignCustomer_ForeignNatioanlID",
                table: "ForeignCustomer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IbanId_BranchId_FromBranchId_HomeAddressId_WorkAddressId_CustomerTypeId_LastCustomerTypeId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_WorkAddressId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "RealCustomer");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LegalCustomer");

            migrationBuilder.DropColumn(
                name: "HomeAddressId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastCustomerTypeId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "WorkAddressId",
                table: "Customer");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "RealCustomer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "RealCustomer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdCard",
                table: "Customer",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "IbanId",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForeignCustomerId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LegalCustomerId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RealCustomerId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AddressId",
                table: "Customer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ForeignCustomerId",
                table: "Customer",
                column: "ForeignCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LegalCustomerId",
                table: "Customer",
                column: "LegalCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RealCustomerId",
                table: "Customer",
                column: "RealCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ForeignCustomer_ForeignCustomerId",
                table: "Customer",
                column: "ForeignCustomerId",
                principalTable: "ForeignCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_LegalCustomer_LegalCustomerId",
                table: "Customer",
                column: "LegalCustomerId",
                principalTable: "LegalCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_RealCustomer_RealCustomerId",
                table: "Customer",
                column: "RealCustomerId",
                principalTable: "RealCustomer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_Address_AddressId",
                table: "Repository",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ForeignCustomer_ForeignCustomerId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_LegalCustomer_LegalCustomerId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_RealCustomer_RealCustomerId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Repository_Address_AddressId",
                table: "Repository");

            migrationBuilder.DropIndex(
                name: "IX_Customer_AddressId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ForeignCustomerId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_LegalCustomerId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_RealCustomerId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "RealCustomer");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ForeignCustomerId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LegalCustomerId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "RealCustomerId",
                table: "Customer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "RealCustomer",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "NationalId",
                table: "RealCustomer",
                type: "uniqueidentifier",
                maxLength: 10,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "LegalCustomer",
                type: "uniqueidentifier",
                maxLength: 11,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "IdCard",
                table: "Customer",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "IbanId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "HomeAddressId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastCustomerTypeId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkAddressId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealCustomer_NationalId",
                table: "RealCustomer",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCustomer_CompanyId",
                table: "LegalCustomer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignCustomer_ForeignNatioanlID",
                table: "ForeignCustomer",
                column: "ForeignNatioanlID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IbanId_BranchId_FromBranchId_HomeAddressId_WorkAddressId_CustomerTypeId_LastCustomerTypeId",
                table: "Customer",
                columns: new[] { "IbanId", "BranchId", "FromBranchId", "HomeAddressId", "WorkAddressId", "CustomerTypeId", "LastCustomerTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_WorkAddressId",
                table: "Customer",
                column: "WorkAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_WorkAddressId",
                table: "Customer",
                column: "WorkAddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignCustomer_Customer_ForeignNatioanlID",
                table: "ForeignCustomer",
                column: "ForeignNatioanlID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCustomer_Customer_CompanyId",
                table: "LegalCustomer",
                column: "CompanyId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealCustomer_Customer_NationalId",
                table: "RealCustomer",
                column: "NationalId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
