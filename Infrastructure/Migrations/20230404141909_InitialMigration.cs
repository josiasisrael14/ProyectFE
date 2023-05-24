using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    IdBox = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeMark = table.Column<string>(type: "varchar(60)", nullable: true),
                    Description = table.Column<string>(type: "varchar(60)", nullable: true),
                    BarCode = table.Column<string>(type: "varchar(40)", nullable: true),
                    State = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.IdBox);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    IdProductCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => x.IdProductCategory);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompany = table.Column<string>(type: "varchar(20)", nullable: true),
                    State = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    IdDocumentType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsSunat = table.Column<string>(type: "varchar(60)", nullable: true),
                    CodSunat = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.IdDocumentType);
                });

            migrationBuilder.CreateTable(
                name: "MovementType",
                columns: table => new
                {
                    IdTypeMovement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementType", x => x.IdTypeMovement);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    IdPaymentType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.IdPaymentType);
                });

            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    IdPresentation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.IdPresentation);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    IdTransactionType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.IdTransactionType);
                });

            migrationBuilder.CreateTable(
                name: "TypeClients",
                columns: table => new
                {
                    IdTypeClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeClient = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClients", x => x.IdTypeClient);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    IdUnit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureCodeUnit = table.Column<string>(type: "varchar(100)", nullable: false),
                    MeasureName = table.Column<string>(type: "varchar(50)", nullable: false),
                    MeasureActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.IdUnit);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProductCategory = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Products_CategoryProducts_IdProductCategory",
                        column: x => x.IdProductCategory,
                        principalTable: "CategoryProducts",
                        principalColumn: "IdProductCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    IdBranchOffice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.IdBranchOffice);
                    table.ForeignKey(
                        name: "FK_BranchOffices_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    IdProvider = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompany = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.IdProvider);
                    table.ForeignKey(
                        name: "FK_Providers_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBranchOffice = table.Column<int>(type: "int", nullable: false),
                    IdTypeClient = table.Column<int>(type: "int", nullable: true),
                    DniRucClient = table.Column<string>(type: "varchar(25)", nullable: true),
                    NameClient = table.Column<string>(type: "varchar(100)", nullable: true),
                    DirectionClient = table.Column<string>(type: "varchar(80)", nullable: true),
                    TelephoneClient = table.Column<string>(type: "varchar(20)", nullable: true),
                    State = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Clients_BranchOffices_IdBranchOffice",
                        column: x => x.IdBranchOffice,
                        principalTable: "BranchOffices",
                        principalColumn: "IdBranchOffice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_TypeClients_IdTypeClient",
                        column: x => x.IdTypeClient,
                        principalTable: "TypeClients",
                        principalColumn: "IdTypeClient");
                });

            migrationBuilder.CreateTable(
                name: "FinalProducts",
                columns: table => new
                {
                    IdFinalProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalePrice = table.Column<string>(type: "varchar(60)", nullable: true),
                    IdBranchOffice = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdUnit = table.Column<int>(type: "int", nullable: false),
                    IdPresentation = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<string>(type: "varchar(60)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    FinalProductscol = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalProducts", x => x.IdFinalProduct);
                    table.ForeignKey(
                        name: "FK_FinalProducts_BranchOffices_IdBranchOffice",
                        column: x => x.IdBranchOffice,
                        principalTable: "BranchOffices",
                        principalColumn: "IdBranchOffice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalProducts_Presentations_IdPresentation",
                        column: x => x.IdPresentation,
                        principalTable: "Presentations",
                        principalColumn: "IdPresentation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalProducts_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalProducts_Units_IdUnit",
                        column: x => x.IdUnit,
                        principalTable: "Units",
                        principalColumn: "IdUnit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBranchOffice = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "varchar(20)", nullable: true),
                    Userpass = table.Column<string>(type: "varchar(20)", nullable: true),
                    State = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_BranchOffices_IdBranchOffice",
                        column: x => x.IdBranchOffice,
                        principalTable: "BranchOffices",
                        principalColumn: "IdBranchOffice",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoxOpenings",
                columns: table => new
                {
                    IdBoxOpening = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBox = table.Column<int>(type: "int", nullable: false),
                    OpenDate = table.Column<string>(type: "varchar(60)", nullable: true),
                    ClosingDate = table.Column<string>(type: "varchar(60)", nullable: true),
                    BoxState = table.Column<string>(type: "varchar(60)", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    OpeningAmount = table.Column<string>(type: "varchar(60)", nullable: true),
                    CloseAmount = table.Column<string>(type: "varchar(60)", nullable: true),
                    CurrentAmount = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxOpenings", x => x.IdBoxOpening);
                    table.ForeignKey(
                        name: "FK_BoxOpenings_Boxes_IdBox",
                        column: x => x.IdBox,
                        principalTable: "Boxes",
                        principalColumn: "IdBox",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoxOpenings_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    IdConversion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFinalProduct = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversion", x => x.IdConversion);
                    table.ForeignKey(
                        name: "FK_Conversion_FinalProducts_IdFinalProduct",
                        column: x => x.IdFinalProduct,
                        principalTable: "FinalProducts",
                        principalColumn: "IdFinalProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conversion_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Kardex",
                columns: table => new
                {
                    idKardex = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTypeMovement = table.Column<int>(type: "int", nullable: false),
                    IdFinalProduct = table.Column<int>(type: "int", nullable: false),
                    IdTypeTransaccion = table.Column<string>(type: "varchar(60)", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kardex", x => x.idKardex);
                    table.ForeignKey(
                        name: "FK_Kardex_FinalProducts_IdFinalProduct",
                        column: x => x.IdFinalProduct,
                        principalTable: "FinalProducts",
                        principalColumn: "IdFinalProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kardex_MovementType_idTypeMovement",
                        column: x => x.idTypeMovement,
                        principalTable: "MovementType",
                        principalColumn: "IdTypeMovement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kardex_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdDocumentType = table.Column<int>(type: "int", nullable: false),
                    IdBox = table.Column<int>(type: "int", nullable: false),
                    IdPaymentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK_Sales_Boxes_IdBox",
                        column: x => x.IdBox,
                        principalTable: "Boxes",
                        principalColumn: "IdBox",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_DocumentType_IdDocumentType",
                        column: x => x.IdDocumentType,
                        principalTable: "DocumentType",
                        principalColumn: "IdDocumentType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_PaymentTypes_IdPaymentType",
                        column: x => x.IdPaymentType,
                        principalTable: "PaymentTypes",
                        principalColumn: "IdPaymentType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Shopping",
                columns: table => new
                {
                    IdPurchase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProvider = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdDocumentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping", x => x.IdPurchase);
                    table.ForeignKey(
                        name: "FK_Shopping_DocumentType_IdDocumentType",
                        column: x => x.IdDocumentType,
                        principalTable: "DocumentType",
                        principalColumn: "IdDocumentType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Providers_IdProvider",
                        column: x => x.IdProvider,
                        principalTable: "Providers",
                        principalColumn: "IdProvider",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shopping_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    IdUserRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "varchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.IdUserRole);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movementbox",
                columns: table => new
                {
                    IdMovementbox = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    IdBoxOpening = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<string>(type: "varchar(60)", nullable: true),
                    IdTypeMovement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movementbox", x => x.IdMovementbox);
                    table.ForeignKey(
                        name: "FK_Movementbox_BoxOpenings_IdBoxOpening",
                        column: x => x.IdBoxOpening,
                        principalTable: "BoxOpenings",
                        principalColumn: "IdBoxOpening",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movementbox_MovementType_IdTypeMovement",
                        column: x => x.IdTypeMovement,
                        principalTable: "MovementType",
                        principalColumn: "IdTypeMovement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movementbox_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "DetailConversions",
                columns: table => new
                {
                    IdDetailConversions = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factor = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<int>(type: "int", nullable: true),
                    IdConversion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailConversions", x => x.IdDetailConversions);
                    table.ForeignKey(
                        name: "FK_DetailConversions_Conversion_IdConversion",
                        column: x => x.IdConversion,
                        principalTable: "Conversion",
                        principalColumn: "IdConversion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetail",
                columns: table => new
                {
                    IdSaleDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSale = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<string>(type: "varchar(60)", nullable: true),
                    SalePrice = table.Column<string>(type: "varchar(60)", nullable: true),
                    SubTotal = table.Column<string>(type: "varchar(60)", nullable: true),
                    IdFinalProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetail", x => x.IdSaleDetail);
                    table.ForeignKey(
                        name: "FK_SalesDetail_FinalProducts_IdFinalProduct",
                        column: x => x.IdFinalProduct,
                        principalTable: "FinalProducts",
                        principalColumn: "IdFinalProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesDetail_Sales_IdSale",
                        column: x => x.IdSale,
                        principalTable: "Sales",
                        principalColumn: "IdSale");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    IdSchedule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSale = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<string>(type: "varchar(60)", nullable: true),
                    QuotaAmount = table.Column<string>(type: "varchar(60)", nullable: true),
                    AmountPaid = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.IdSchedule);
                    table.ForeignKey(
                        name: "FK_Schedules_Sales_IdSale",
                        column: x => x.IdSale,
                        principalTable: "Sales",
                        principalColumn: "IdSale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailShopping",
                columns: table => new
                {
                    IdDetailShopping = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPurchase = table.Column<int>(type: "int", nullable: true),
                    IdFinalProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailShopping", x => x.IdDetailShopping);
                    table.ForeignKey(
                        name: "FK_DetailShopping_FinalProducts_IdFinalProduct",
                        column: x => x.IdFinalProduct,
                        principalTable: "FinalProducts",
                        principalColumn: "IdFinalProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailShopping_Shopping_IdPurchase",
                        column: x => x.IdPurchase,
                        principalTable: "Shopping",
                        principalColumn: "IdPurchase");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSchedule = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<string>(type: "varchar(60)", nullable: true),
                    PaymentAmount = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK_Payments_Schedules_IdSchedule",
                        column: x => x.IdSchedule,
                        principalTable: "Schedules",
                        principalColumn: "IdSchedule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxOpenings_IdBox",
                table: "BoxOpenings",
                column: "IdBox");

            migrationBuilder.CreateIndex(
                name: "IX_BoxOpenings_IdUser",
                table: "BoxOpenings",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_IdCompany",
                table: "BranchOffices",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdBranchOffice",
                table: "Clients",
                column: "IdBranchOffice");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdTypeClient",
                table: "Clients",
                column: "IdTypeClient");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_IdFinalProduct",
                table: "Conversion",
                column: "IdFinalProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_IdUser",
                table: "Conversion",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_DetailConversions_IdConversion",
                table: "DetailConversions",
                column: "IdConversion");

            migrationBuilder.CreateIndex(
                name: "IX_DetailShopping_IdFinalProduct",
                table: "DetailShopping",
                column: "IdFinalProduct");

            migrationBuilder.CreateIndex(
                name: "IX_DetailShopping_IdPurchase",
                table: "DetailShopping",
                column: "IdPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_IdBranchOffice",
                table: "FinalProducts",
                column: "IdBranchOffice");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_IdPresentation",
                table: "FinalProducts",
                column: "IdPresentation");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_IdProduct",
                table: "FinalProducts",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_IdUnit",
                table: "FinalProducts",
                column: "IdUnit");

            migrationBuilder.CreateIndex(
                name: "IX_Kardex_IdFinalProduct",
                table: "Kardex",
                column: "IdFinalProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Kardex_idTypeMovement",
                table: "Kardex",
                column: "idTypeMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Kardex_IdUser",
                table: "Kardex",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Movementbox_IdBoxOpening",
                table: "Movementbox",
                column: "IdBoxOpening");

            migrationBuilder.CreateIndex(
                name: "IX_Movementbox_IdTypeMovement",
                table: "Movementbox",
                column: "IdTypeMovement");

            migrationBuilder.CreateIndex(
                name: "IX_Movementbox_IdUser",
                table: "Movementbox",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdSchedule",
                table: "Payments",
                column: "IdSchedule");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProductCategory",
                table: "Products",
                column: "IdProductCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_IdCompany",
                table: "Providers",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdBox",
                table: "Sales",
                column: "IdBox");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdClient",
                table: "Sales",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdDocumentType",
                table: "Sales",
                column: "IdDocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdPaymentType",
                table: "Sales",
                column: "IdPaymentType");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdUser",
                table: "Sales",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_IdFinalProduct",
                table: "SalesDetail",
                column: "IdFinalProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetail_IdSale",
                table: "SalesDetail",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_IdSale",
                table: "Schedules",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_IdDocumentType",
                table: "Shopping",
                column: "IdDocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_IdProvider",
                table: "Shopping",
                column: "IdProvider");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_IdUser",
                table: "Shopping",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_IdRole",
                table: "UserRoles",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_IdUser",
                table: "UserRoles",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdBranchOffice",
                table: "Users",
                column: "IdBranchOffice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailConversions");

            migrationBuilder.DropTable(
                name: "DetailShopping");

            migrationBuilder.DropTable(
                name: "Kardex");

            migrationBuilder.DropTable(
                name: "Movementbox");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SalesDetail");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Conversion");

            migrationBuilder.DropTable(
                name: "Shopping");

            migrationBuilder.DropTable(
                name: "BoxOpenings");

            migrationBuilder.DropTable(
                name: "MovementType");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "FinalProducts");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "TypeClients");

            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
