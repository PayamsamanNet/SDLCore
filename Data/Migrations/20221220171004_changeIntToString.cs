using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class changeIntToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Contracts_ContractId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Sms_Contracts_ContractId",
                table: "Sms");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Contracts_ContractId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "ContractDetail");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "StateCode",
                table: "State",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Agreement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerRole = table.Column<int>(type: "int", nullable: false),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountEntry = table.Column<int>(type: "int", nullable: true),
                    UnBlockDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractState = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BlockedNumber = table.Column<int>(type: "int", nullable: true),
                    TrustPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractScanImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractExtScanImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastBoxState = table.Column<int>(type: "int", nullable: false),
                    ContractStep = table.Column<int>(type: "int", nullable: false),
                    MifareCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MifareRegistrationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MifareRestart = table.Column<bool>(type: "bit", nullable: true),
                    GateWasOpened = table.Column<bool>(type: "bit", nullable: true),
                    GateWasOpenedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlockedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnblockContractImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastContractStep = table.Column<int>(type: "int", nullable: true),
                    ContractBlockType = table.Column<int>(type: "int", nullable: true),
                    WholeEntrance = table.Column<int>(type: "int", nullable: true),
                    UsedEntrance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreement_Box_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Box",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agreement_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgreemnetDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerContractRole = table.Column<int>(type: "int", nullable: false),
                    IsLawyer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreemnetDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgreemnetDetail_Agreement_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Agreement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_BoxId",
                table: "Agreement",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_CustomerId_InsuranceId_BranchId",
                table: "Agreement",
                columns: new[] { "CustomerId", "InsuranceId", "BranchId" });

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_InsuranceId",
                table: "Agreement",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_AgreemnetDetail_ContractId",
                table: "AgreemnetDetail",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Agreement_ContractId",
                table: "Log",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sms_Agreement_ContractId",
                table: "Sms",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Agreement_ContractId",
                table: "Transaction",
                column: "ContractId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Agreement_ContractId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Sms_Agreement_ContractId",
                table: "Sms");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Agreement_ContractId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "AgreemnetDetail");

            migrationBuilder.DropTable(
                name: "Agreement");

            migrationBuilder.AlterColumn<int>(
                name: "StateCode",
                table: "State",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlockDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlockedNumber = table.Column<int>(type: "int", nullable: true),
                    BlockedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CancelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractBlockType = table.Column<int>(type: "int", nullable: true),
                    ContractExtScanImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractScanImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractState = table.Column<int>(type: "int", nullable: false),
                    ContractStep = table.Column<int>(type: "int", nullable: false),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    CountEntry = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerRole = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GateWasOpened = table.Column<bool>(type: "bit", nullable: true),
                    GateWasOpenedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastBoxState = table.Column<int>(type: "int", nullable: false),
                    LastContractStep = table.Column<int>(type: "int", nullable: true),
                    MifareCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MifareRegistrationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MifareRestart = table.Column<bool>(type: "bit", nullable: true),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrustPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnBlockDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnblockContractImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedEntrance = table.Column<int>(type: "int", nullable: true),
                    WholeEntrance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Box_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Box",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Insurance_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerContractRole = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLawyer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDetail_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractDetail_ContractId",
                table: "ContractDetail",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BoxId",
                table: "Contracts",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CustomerId_InsuranceId_BranchId",
                table: "Contracts",
                columns: new[] { "CustomerId", "InsuranceId", "BranchId" });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_InsuranceId",
                table: "Contracts",
                column: "InsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Contracts_ContractId",
                table: "Log",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sms_Contracts_ContractId",
                table: "Sms",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Contracts_ContractId",
                table: "Transaction",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
