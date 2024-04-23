using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    IdCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    IdContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.IdContact);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    IdIdentificationType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentifiType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.IdIdentificationType);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    IdPost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.IdPost);
                });

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    IdQuality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.IdQuality);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    IdSalesDetails = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.IdSalesDetails);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    IdState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    IdSupplies = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSupplies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.IdSupplies);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_Address_City_IdCity",
                        column: x => x.IdCity,
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                columns: table => new
                {
                    IdTracking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTracking = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdState = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.IdTracking);
                    table.ForeignKey(
                        name: "FK_Tracking_State_IdState",
                        column: x => x.IdState,
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
                columns: table => new
                {
                    IdPurchaseDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupplies = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.IdPurchaseDetail);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Supplies_IdSupplies",
                        column: x => x.IdSupplies,
                        principalTable: "Supplies",
                        principalColumn: "IdSupplies",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdContact = table.Column<int>(type: "int", nullable: false),
                    IdTypeIdentification = table.Column<int>(type: "int", nullable: false),
                    NumberIdentification = table.Column<int>(type: "int", nullable: false),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Person_Address_IdAddress",
                        column: x => x.IdAddress,
                        principalTable: "Address",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Contact_IdContact",
                        column: x => x.IdContact,
                        principalTable: "Contact",
                        principalColumn: "IdContact",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_IdentificationType_IdTypeIdentification",
                        column: x => x.IdTypeIdentification,
                        principalTable: "IdentificationType",
                        principalColumn: "IdIdentificationType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployees = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployees);
                    table.ForeignKey(
                        name: "FK_Employees_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Post_IdPost",
                        column: x => x.IdPost,
                        principalTable: "Post",
                        principalColumn: "IdPost",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    IdProviders = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.IdProviders);
                    table.ForeignKey(
                        name: "FK_Providers_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillSale",
                columns: table => new
                {
                    IdBillSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSalesDetails = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSale", x => x.IdBillSale);
                    table.ForeignKey(
                        name: "FK_BillSale_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillSale_SalesDetails_IdSalesDetails",
                        column: x => x.IdSalesDetails,
                        principalTable: "SalesDetails",
                        principalColumn: "IdSalesDetails",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dispatch",
                columns: table => new
                {
                    IdDispatch = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployees = table.Column<int>(type: "int", nullable: false),
                    IdSalesDetails = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTracking = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatch", x => x.IdDispatch);
                    table.ForeignKey(
                        name: "FK_Dispatch_Employees_IdEmployees",
                        column: x => x.IdEmployees,
                        principalTable: "Employees",
                        principalColumn: "IdEmployees",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dispatch_SalesDetails_IdSalesDetails",
                        column: x => x.IdSalesDetails,
                        principalTable: "SalesDetails",
                        principalColumn: "IdSalesDetails",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dispatch_Tracking_IdTracking",
                        column: x => x.IdTracking,
                        principalTable: "Tracking",
                        principalColumn: "IdTracking",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    IdHarvests = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarvestAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idemployees = table.Column<int>(type: "int", nullable: false),
                    IdQuality = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.IdHarvests);
                    table.ForeignKey(
                        name: "FK_Harvests_Employees_Idemployees",
                        column: x => x.Idemployees,
                        principalTable: "Employees",
                        principalColumn: "IdEmployees",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Harvests_Quality_IdQuality",
                        column: x => x.IdQuality,
                        principalTable: "Quality",
                        principalColumn: "IdQuality",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvidervsInputs",
                columns: table => new
                {
                    IdProvsInp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProviders = table.Column<int>(type: "int", nullable: false),
                    IdSupplies = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidervsInputs", x => x.IdProvsInp);
                    table.ForeignKey(
                        name: "FK_ProvidervsInputs_Providers_IdProviders",
                        column: x => x.IdProviders,
                        principalTable: "Providers",
                        principalColumn: "IdProviders",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidervsInputs_Supplies_IdSupplies",
                        column: x => x.IdSupplies,
                        principalTable: "Supplies",
                        principalColumn: "IdSupplies",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    IdPurchase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProviders = table.Column<int>(type: "int", nullable: false),
                    DateProviders = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPurchaseDetail = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.IdPurchase);
                    table.ForeignKey(
                        name: "FK_Purchase_Providers_IdProviders",
                        column: x => x.IdProviders,
                        principalTable: "Providers",
                        principalColumn: "IdProviders",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_PurchaseDetail_IdPurchaseDetail",
                        column: x => x.IdPurchaseDetail,
                        principalTable: "PurchaseDetail",
                        principalColumn: "IdPurchaseDetail",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    IdStorage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdHarvests = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.IdStorage);
                    table.ForeignKey(
                        name: "FK_Storage_Harvests_IdHarvests",
                        column: x => x.IdHarvests,
                        principalTable: "Harvests",
                        principalColumn: "IdHarvests",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_IdCity",
                table: "Address",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_BillSale_IdClient",
                table: "BillSale",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_BillSale_IdSalesDetails",
                table: "BillSale",
                column: "IdSalesDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdPerson",
                table: "Client",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatch_IdEmployees",
                table: "Dispatch",
                column: "IdEmployees");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatch_IdSalesDetails",
                table: "Dispatch",
                column: "IdSalesDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatch_IdTracking",
                table: "Dispatch",
                column: "IdTracking");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdPerson",
                table: "Employees",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdPost",
                table: "Employees",
                column: "IdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_Idemployees",
                table: "Harvests",
                column: "Idemployees");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_IdQuality",
                table: "Harvests",
                column: "IdQuality");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdAddress",
                table: "Person",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdContact",
                table: "Person",
                column: "IdContact");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IdTypeIdentification",
                table: "Person",
                column: "IdTypeIdentification");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_IdPerson",
                table: "Providers",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidervsInputs_IdProviders",
                table: "ProvidervsInputs",
                column: "IdProviders");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidervsInputs_IdSupplies",
                table: "ProvidervsInputs",
                column: "IdSupplies");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_IdProviders",
                table: "Purchase",
                column: "IdProviders");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_IdPurchaseDetail",
                table: "Purchase",
                column: "IdPurchaseDetail");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_IdSupplies",
                table: "PurchaseDetail",
                column: "IdSupplies");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_IdHarvests",
                table: "Storage",
                column: "IdHarvests");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_IdState",
                table: "Tracking",
                column: "IdState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillSale");

            migrationBuilder.DropTable(
                name: "Dispatch");

            migrationBuilder.DropTable(
                name: "ProvidervsInputs");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "Tracking");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "PurchaseDetail");

            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Quality");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
