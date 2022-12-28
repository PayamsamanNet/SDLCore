using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class FirstTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoxType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Depth = table.Column<int>(type: "int", nullable: false),
                    MonthlyPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrustPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BlockedPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RunningPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShortDatePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LongDatePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchManagerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchManager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrustPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BlockedPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EntranceRatio = table.Column<int>(type: "int", nullable: false),
                    EntrancePackagePrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrustPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BlockedPriceRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompanyNameService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwearCeiling = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumRates = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UntilAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repository",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopPlanImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopPlanDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstallationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repository", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repository_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repository_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepositoryColumn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepositoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ColumnTypes = table.Column<int>(type: "int", nullable: false),
                    FromBoxNumber = table.Column<int>(type: "int", nullable: false),
                    ToBoxNumber = table.Column<int>(type: "int", nullable: false),
                    ColumnStyleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryColumn_Repository_RepositoryId",
                        column: x => x.RepositoryId,
                        principalTable: "Repository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TellPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tell = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    NumStr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepositoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColumnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoxTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoxState = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    IsVip = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Box_BoxType_BoxTypeId",
                        column: x => x.BoxTypeId,
                        principalTable: "BoxType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Box_RepositoryColumn_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "RepositoryColumn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deputy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchManagerCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Address_BranchAddressId",
                        column: x => x.BranchAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch_BranchManager_BranchManagerCode",
                        column: x => x.BranchManagerCode,
                        principalTable: "BranchManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branch_RegionCode_AreaCode",
                        column: x => x.AreaCode,
                        principalTable: "RegionCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCard = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IbanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromBranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastCustomerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Address_WorkAddressId",
                        column: x => x.WorkAddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customer_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_CustomerType_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "RepositoryToBranch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepositoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAllowed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepositoryToBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepositoryToBranch_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepositoryToBranch_Repository_RepositoryId",
                        column: x => x.RepositoryId,
                        principalTable: "Repository",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeignCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForeignNatioanlID = table.Column<Guid>(type: "uniqueidentifier", maxLength: 12, nullable: false),
                    PassportNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignCustomer_Customer_ForeignNatioanlID",
                        column: x => x.ForeignNatioanlID,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iban",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNum = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IbanNumber = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iban", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iban_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lawyer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MandateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MandateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MandateStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MandateEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MandateScanImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MifareCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MifareRegistrationId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanOpenBox = table.Column<bool>(type: "bit", nullable: false),
                    LawyerStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawyer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lawyer_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 11, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficialGazetteNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficialGazetteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastVisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalCustomer_Customer_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealCustomer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealCustomer_Customer_NationalId",
                        column: x => x.NationalId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractDetail",
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
                    table.PrimaryKey("PK_ContractDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDetail_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Machine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RepositoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberOfTry = table.Column<int>(type: "int", nullable: false),
                    MaxNumberOfTry = table.Column<int>(type: "int", nullable: false),
                    LastTryTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sms_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransNumber = table.Column<int>(type: "int", nullable: false),
                    Extra = table.Column<int>(type: "int", nullable: false),
                    TransStatus = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransAmnt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Box_BoxTypeId",
                table: "Box",
                column: "BoxTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Box_ColumnId",
                table: "Box",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Box_RepositoryId",
                table: "Box",
                column: "RepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_AreaCode",
                table: "Branch",
                column: "AreaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BankId_DegreeId",
                table: "Branch",
                columns: new[] { "BankId", "DegreeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BranchAddressId",
                table: "Branch",
                column: "BranchAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BranchManagerCode",
                table: "Branch",
                column: "BranchManagerCode");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BankId",
                table: "Customer",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomerTypeId",
                table: "Customer",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IbanId_BranchId_FromBranchId_HomeAddressId_WorkAddressId_CustomerTypeId_LastCustomerTypeId",
                table: "Customer",
                columns: new[] { "IbanId", "BranchId", "FromBranchId", "HomeAddressId", "WorkAddressId", "CustomerTypeId", "LastCustomerTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_WorkAddressId",
                table: "Customer",
                column: "WorkAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignCustomer_ForeignNatioanlID",
                table: "ForeignCustomer",
                column: "ForeignNatioanlID");

            migrationBuilder.CreateIndex(
                name: "IX_Iban_BranchId",
                table: "Iban",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Iban_CustomerId",
                table: "Iban",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lawyer_CustomerId",
                table: "Lawyer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCustomer_CompanyId",
                table: "LegalCustomer",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_BranchId_RepositoryId",
                table: "Log",
                columns: new[] { "BranchId", "RepositoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_Log_ContractId",
                table: "Log",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_RealCustomer_NationalId",
                table: "RealCustomer",
                column: "NationalId");

            migrationBuilder.CreateIndex(
                name: "IX_Repository_AddressId",
                table: "Repository",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Repository_BankId",
                table: "Repository",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Repository_DegreeId",
                table: "Repository",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryColumn_RepositoryId",
                table: "RepositoryColumn",
                column: "RepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryToBranch_BranchId",
                table: "RepositoryToBranch",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RepositoryToBranch_RepositoryId",
                table: "RepositoryToBranch",
                column: "RepositoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sms_ContractId",
                table: "Sms",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ContractId",
                table: "Transaction",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractDetail");

            migrationBuilder.DropTable(
                name: "ForeignCustomer");

            migrationBuilder.DropTable(
                name: "Iban");

            migrationBuilder.DropTable(
                name: "Lawyer");

            migrationBuilder.DropTable(
                name: "LegalCustomer");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "RealCustomer");

            migrationBuilder.DropTable(
                name: "RepositoryToBranch");

            migrationBuilder.DropTable(
                name: "Sms");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "CustomerType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BranchManager");

            migrationBuilder.DropTable(
                name: "RegionCode");

            migrationBuilder.DropTable(
                name: "Box");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "BoxType");

            migrationBuilder.DropTable(
                name: "RepositoryColumn");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Repository");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Degree");
        }
    }
}
