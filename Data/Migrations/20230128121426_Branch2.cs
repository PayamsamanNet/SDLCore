using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Branch2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreement_Box_BoxId",
                table: "Agreement");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreement_Insurance_InsuranceId",
                table: "Agreement");

            migrationBuilder.DropForeignKey(
                name: "FK_AgreementDetail_Agreement_ContractId",
                table: "AgreementDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Box_BoxType_BoxTypeId",
                table: "Box");

            migrationBuilder.DropForeignKey(
                name: "FK_Box_RepositoryColumn_ColumnId",
                table: "Box");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Address_BranchAddressId",
                table: "Branch");

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

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Bank_BankId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerType_CustomerTypeId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignCustomer_Customer_ForeignNatioanlID",
                table: "ForeignCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Iban_Customer_CustomerId",
                table: "Iban");

            migrationBuilder.DropForeignKey(
                name: "FK_Lawyer_Customer_CustomerId",
                table: "Lawyer");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCustomer_Customer_CompanyId",
                table: "LegalCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Agreement_ContractId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_RealCustomer_Customer_NationalId",
                table: "RealCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Repository_Bank_BankId",
                table: "Repository");

            migrationBuilder.DropForeignKey(
                name: "FK_Repository_Degree_DegreeId",
                table: "Repository");

            migrationBuilder.DropForeignKey(
                name: "FK_RepositoryColumn_Repository_RepositoryId",
                table: "RepositoryColumn");

            migrationBuilder.DropForeignKey(
                name: "FK_RepositoryToBranch_Branch_BranchId",
                table: "RepositoryToBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_RepositoryToBranch_Repository_RepositoryId",
                table: "RepositoryToBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_AspNetRoles_RoleId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Agreement_ContractId",
                table: "Transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreement_Box_BoxId",
                table: "Agreement",
                column: "BoxId",
                principalTable: "Box",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreement_Insurance_InsuranceId",
                table: "Agreement",
                column: "InsuranceId",
                principalTable: "Insurance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AgreementDetail_Agreement_ContractId",
                table: "AgreementDetail",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Box_BoxType_BoxTypeId",
                table: "Box",
                column: "BoxTypeId",
                principalTable: "BoxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Box_RepositoryColumn_ColumnId",
                table: "Box",
                column: "ColumnId",
                principalTable: "RepositoryColumn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Address_BranchAddressId",
                table: "Branch",
                column: "BranchAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Bank_BankId",
                table: "Branch",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_BranchManager_BranchManagerId",
                table: "Branch",
                column: "BranchManagerId",
                principalTable: "BranchManager",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Degree_DegreeId",
                table: "Branch",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_RegionCode_AreaId",
                table: "Branch",
                column: "AreaId",
                principalTable: "RegionCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Bank_BankId",
                table: "Customer",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerType_CustomerTypeId",
                table: "Customer",
                column: "CustomerTypeId",
                principalTable: "CustomerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignCustomer_Customer_ForeignNatioanlID",
                table: "ForeignCustomer",
                column: "ForeignNatioanlID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Iban_Customer_CustomerId",
                table: "Iban",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lawyer_Customer_CustomerId",
                table: "Lawyer",
                column: "CustomerId",
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
                name: "FK_Log_Agreement_ContractId",
                table: "Log",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealCustomer_Customer_NationalId",
                table: "RealCustomer",
                column: "NationalId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_Bank_BankId",
                table: "Repository",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_Degree_DegreeId",
                table: "Repository",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepositoryColumn_Repository_RepositoryId",
                table: "RepositoryColumn",
                column: "RepositoryId",
                principalTable: "Repository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepositoryToBranch_Branch_BranchId",
                table: "RepositoryToBranch",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepositoryToBranch_Repository_RepositoryId",
                table: "RepositoryToBranch",
                column: "RepositoryId",
                principalTable: "Repository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_AspNetRoles_RoleId",
                table: "RolePermission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Agreement_ContractId",
                table: "Transaction",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreement_Box_BoxId",
                table: "Agreement");

            migrationBuilder.DropForeignKey(
                name: "FK_Agreement_Insurance_InsuranceId",
                table: "Agreement");

            migrationBuilder.DropForeignKey(
                name: "FK_AgreementDetail_Agreement_ContractId",
                table: "AgreementDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Box_BoxType_BoxTypeId",
                table: "Box");

            migrationBuilder.DropForeignKey(
                name: "FK_Box_RepositoryColumn_ColumnId",
                table: "Box");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Address_BranchAddressId",
                table: "Branch");

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

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Bank_BankId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_CustomerType_CustomerTypeId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignCustomer_Customer_ForeignNatioanlID",
                table: "ForeignCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Iban_Customer_CustomerId",
                table: "Iban");

            migrationBuilder.DropForeignKey(
                name: "FK_Lawyer_Customer_CustomerId",
                table: "Lawyer");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCustomer_Customer_CompanyId",
                table: "LegalCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Agreement_ContractId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_RealCustomer_Customer_NationalId",
                table: "RealCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_Repository_Bank_BankId",
                table: "Repository");

            migrationBuilder.DropForeignKey(
                name: "FK_Repository_Degree_DegreeId",
                table: "Repository");

            migrationBuilder.DropForeignKey(
                name: "FK_RepositoryColumn_Repository_RepositoryId",
                table: "RepositoryColumn");

            migrationBuilder.DropForeignKey(
                name: "FK_RepositoryToBranch_Branch_BranchId",
                table: "RepositoryToBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_RepositoryToBranch_Repository_RepositoryId",
                table: "RepositoryToBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_AspNetRoles_RoleId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Agreement_ContractId",
                table: "Transaction");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreement_Box_BoxId",
                table: "Agreement",
                column: "BoxId",
                principalTable: "Box",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreement_Insurance_InsuranceId",
                table: "Agreement",
                column: "InsuranceId",
                principalTable: "Insurance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AgreementDetail_Agreement_ContractId",
                table: "AgreementDetail",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Box_BoxType_BoxTypeId",
                table: "Box",
                column: "BoxTypeId",
                principalTable: "BoxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Box_RepositoryColumn_ColumnId",
                table: "Box",
                column: "ColumnId",
                principalTable: "RepositoryColumn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Address_BranchAddressId",
                table: "Branch",
                column: "BranchAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Bank_BankId",
                table: "Customer",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_CustomerType_CustomerTypeId",
                table: "Customer",
                column: "CustomerTypeId",
                principalTable: "CustomerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignCustomer_Customer_ForeignNatioanlID",
                table: "ForeignCustomer",
                column: "ForeignNatioanlID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Iban_Customer_CustomerId",
                table: "Iban",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lawyer_Customer_CustomerId",
                table: "Lawyer",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCustomer_Customer_CompanyId",
                table: "LegalCustomer",
                column: "CompanyId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Agreement_ContractId",
                table: "Log",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealCustomer_Customer_NationalId",
                table: "RealCustomer",
                column: "NationalId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_Bank_BankId",
                table: "Repository",
                column: "BankId",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repository_Degree_DegreeId",
                table: "Repository",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepositoryColumn_Repository_RepositoryId",
                table: "RepositoryColumn",
                column: "RepositoryId",
                principalTable: "Repository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepositoryToBranch_Branch_BranchId",
                table: "RepositoryToBranch",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepositoryToBranch_Repository_RepositoryId",
                table: "RepositoryToBranch",
                column: "RepositoryId",
                principalTable: "Repository",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_AspNetRoles_RoleId",
                table: "RolePermission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permission_PermissionId",
                table: "RolePermission",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Agreement_ContractId",
                table: "Transaction",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
