using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CityIdCity = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_Address_City_CityIdCity",
                        column: x => x.CityIdCity,
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
                    StateIdState = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.IdTracking);
                    table.ForeignKey(
                        name: "FK_Tracking_State_StateIdState",
                        column: x => x.StateIdState,
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
                    SuppliesIdSupplies = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchasePrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.IdPurchaseDetail);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Supplies_SuppliesIdSupplies",
                        column: x => x.SuppliesIdSupplies,
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
                    ContactIdContact = table.Column<int>(type: "int", nullable: false),
                    IdTypeIdentification = table.Column<int>(type: "int", nullable: false),
                    TypeIdentificationIdIdentificationType = table.Column<int>(type: "int", nullable: false),
                    NumberIdentification = table.Column<int>(type: "int", nullable: false),
                    IdAddress = table.Column<int>(type: "int", nullable: false),
                    AddressIdAddress = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressIdAddress",
                        column: x => x.AddressIdAddress,
                        principalTable: "Address",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Contact_ContactIdContact",
                        column: x => x.ContactIdContact,
                        principalTable: "Contact",
                        principalColumn: "IdContact",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_IdentificationType_TypeIdentificationIdIdentificationType",
                        column: x => x.TypeIdentificationIdIdentificationType,
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
                    PersonIdPerson = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_Person_PersonIdPerson",
                        column: x => x.PersonIdPerson,
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
                    PostIdPost = table.Column<int>(type: "int", nullable: false),
                    IdPerson = table.Column<int>(type: "int", nullable: false),
                    PersonIdPerson = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployees);
                    table.ForeignKey(
                        name: "FK_Employees_Person_PersonIdPerson",
                        column: x => x.PersonIdPerson,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Post_PostIdPost",
                        column: x => x.PostIdPost,
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
                    PersonIdPerson = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.IdProviders);
                    table.ForeignKey(
                        name: "FK_Providers_Person_PersonIdPerson",
                        column: x => x.PersonIdPerson,
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
                    ClientIdClient = table.Column<int>(type: "int", nullable: false),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSalesDetails = table.Column<int>(type: "int", nullable: false),
                    SalesDetailsIdSalesDetails = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSale", x => x.IdBillSale);
                    table.ForeignKey(
                        name: "FK_BillSale_Client_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillSale_SalesDetails_SalesDetailsIdSalesDetails",
                        column: x => x.SalesDetailsIdSalesDetails,
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
                    EmployeesIdEmployees = table.Column<int>(type: "int", nullable: false),
                    IdSalesDetails = table.Column<int>(type: "int", nullable: false),
                    SalesDetailsIdSalesDetails = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTracking = table.Column<int>(type: "int", nullable: false),
                    TrackingIdTracking = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatch", x => x.IdDispatch);
                    table.ForeignKey(
                        name: "FK_Dispatch_Employees_EmployeesIdEmployees",
                        column: x => x.EmployeesIdEmployees,
                        principalTable: "Employees",
                        principalColumn: "IdEmployees",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dispatch_SalesDetails_SalesDetailsIdSalesDetails",
                        column: x => x.SalesDetailsIdSalesDetails,
                        principalTable: "SalesDetails",
                        principalColumn: "IdSalesDetails",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dispatch_Tracking_TrackingIdTracking",
                        column: x => x.TrackingIdTracking,
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
                    EmployeesIdEmployees = table.Column<int>(type: "int", nullable: false),
                    IdQuality = table.Column<int>(type: "int", nullable: false),
                    QualityIdQuality = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.IdHarvests);
                    table.ForeignKey(
                        name: "FK_Harvests_Employees_EmployeesIdEmployees",
                        column: x => x.EmployeesIdEmployees,
                        principalTable: "Employees",
                        principalColumn: "IdEmployees",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Harvests_Quality_QualityIdQuality",
                        column: x => x.QualityIdQuality,
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
                    ProvidersIdProviders = table.Column<int>(type: "int", nullable: false),
                    IdSupplies = table.Column<int>(type: "int", nullable: false),
                    SuppliesIdSupplies = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidervsInputs", x => x.IdProvsInp);
                    table.ForeignKey(
                        name: "FK_ProvidervsInputs_Providers_ProvidersIdProviders",
                        column: x => x.ProvidersIdProviders,
                        principalTable: "Providers",
                        principalColumn: "IdProviders",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvidervsInputs_Supplies_SuppliesIdSupplies",
                        column: x => x.SuppliesIdSupplies,
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
                    ProvidersIdProviders = table.Column<int>(type: "int", nullable: false),
                    DateProviders = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdPurchaseDetail = table.Column<int>(type: "int", nullable: false),
                    PurchaseDetailIdPurchaseDetail = table.Column<int>(type: "int", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.IdPurchase);
                    table.ForeignKey(
                        name: "FK_Purchase_Providers_ProvidersIdProviders",
                        column: x => x.ProvidersIdProviders,
                        principalTable: "Providers",
                        principalColumn: "IdProviders",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_PurchaseDetail_PurchaseDetailIdPurchaseDetail",
                        column: x => x.PurchaseDetailIdPurchaseDetail,
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
                    HarvestsIdHarvests = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.IdStorage);
                    table.ForeignKey(
                        name: "FK_Storage_Harvests_HarvestsIdHarvests",
                        column: x => x.HarvestsIdHarvests,
                        principalTable: "Harvests",
                        principalColumn: "IdHarvests",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityIdCity",
                table: "Address",
                column: "CityIdCity");

            migrationBuilder.CreateIndex(
                name: "IX_BillSale_ClientIdClient",
                table: "BillSale",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_BillSale_SalesDetailsIdSalesDetails",
                table: "BillSale",
                column: "SalesDetailsIdSalesDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Client_PersonIdPerson",
                table: "Client",
                column: "PersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatch_EmployeesIdEmployees",
                table: "Dispatch",
                column: "EmployeesIdEmployees");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatch_SalesDetailsIdSalesDetails",
                table: "Dispatch",
                column: "SalesDetailsIdSalesDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatch_TrackingIdTracking",
                table: "Dispatch",
                column: "TrackingIdTracking");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonIdPerson",
                table: "Employees",
                column: "PersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PostIdPost",
                table: "Employees",
                column: "PostIdPost");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_EmployeesIdEmployees",
                table: "Harvests",
                column: "EmployeesIdEmployees");

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_QualityIdQuality",
                table: "Harvests",
                column: "QualityIdQuality");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressIdAddress",
                table: "Person",
                column: "AddressIdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ContactIdContact",
                table: "Person",
                column: "ContactIdContact");

            migrationBuilder.CreateIndex(
                name: "IX_Person_TypeIdentificationIdIdentificationType",
                table: "Person",
                column: "TypeIdentificationIdIdentificationType");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_PersonIdPerson",
                table: "Providers",
                column: "PersonIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidervsInputs_ProvidersIdProviders",
                table: "ProvidervsInputs",
                column: "ProvidersIdProviders");

            migrationBuilder.CreateIndex(
                name: "IX_ProvidervsInputs_SuppliesIdSupplies",
                table: "ProvidervsInputs",
                column: "SuppliesIdSupplies");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ProvidersIdProviders",
                table: "Purchase",
                column: "ProvidersIdProviders");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PurchaseDetailIdPurchaseDetail",
                table: "Purchase",
                column: "PurchaseDetailIdPurchaseDetail");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_SuppliesIdSupplies",
                table: "PurchaseDetail",
                column: "SuppliesIdSupplies");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_HarvestsIdHarvests",
                table: "Storage",
                column: "HarvestsIdHarvests");

            migrationBuilder.CreateIndex(
                name: "IX_Tracking_StateIdState",
                table: "Tracking",
                column: "StateIdState");
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
