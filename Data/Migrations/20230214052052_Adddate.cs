using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Adddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "UserAccount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Transaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "State",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Sms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "RolePermission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "RepositoryToBranch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "RepositoryColumn",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Repository",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "RegionCode",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "RealCustomer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Permission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Log",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "LegalCustomer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Lawyer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Insurance",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Iban",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "ForeignCustomer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Degree",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "CustomerType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "BranchManager",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "BoxType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Box",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Bank",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "AgreementDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Agreement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOperation",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "State");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Sms");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "RolePermission");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "RepositoryToBranch");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "RepositoryColumn");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Repository");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "RegionCode");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "RealCustomer");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "LegalCustomer");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Lawyer");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Insurance");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Iban");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "ForeignCustomer");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Degree");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "CustomerType");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "City");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "BranchManager");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "BoxType");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Box");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Bank");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "AgreementDetail");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Agreement");

            migrationBuilder.DropColumn(
                name: "DateOfOperation",
                table: "Address");
        }
    }
}
