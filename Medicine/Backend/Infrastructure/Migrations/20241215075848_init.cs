using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Substances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternationalName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManufacturerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    MedformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_Medforms_MedformId",
                        column: x => x.MedformId,
                        principalTable: "Medforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoseMedicines",
                columns: table => new
                {
                    DoseId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoseMedicines", x => new { x.DoseId, x.MedicineId });
                    table.ForeignKey(
                        name: "FK_DoseMedicines_Doses_DoseId",
                        column: x => x.DoseId,
                        principalTable: "Doses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoseMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicineSubstances",
                columns: table => new
                {
                    SubstanceId = table.Column<int>(type: "int", nullable: false),
                    MedicineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineSubstances", x => new { x.MedicineId, x.SubstanceId });
                    table.ForeignKey(
                        name: "FK_MedicineSubstances_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineSubstances_Substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { 1, "Uzbekistan" },
                    { 2, "Poland" },
                    { 3, "India" }
                });

            migrationBuilder.InsertData(
                table: "Doses",
                columns: new[] { "Id", "Dosage", "Title" },
                values: new object[,]
                {
                    { 1, 10, "мг" },
                    { 2, 20, "мг" },
                    { 3, 30, "мг" },
                    { 4, 100, "мл" },
                    { 5, 200, "мл" },
                    { 6, 300, "мл" }
                });

            migrationBuilder.InsertData(
                table: "Medforms",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Таблетки" },
                    { 2, "Раствор" },
                    { 3, "Капсула" },
                    { 4, "Капли" },
                    { 5, "Сироп" }
                });

            migrationBuilder.InsertData(
                table: "Substances",
                columns: new[] { "Id", "InternationalName", "TradeName" },
                values: new object[,]
                {
                    { 1, "аланин", "аланин" },
                    { 2, "глицин", "глицин" },
                    { 3, "цетримид", "цетримид" },
                    { 4, "тофизопам", "тофизопам" },
                    { 5, "сорбитол", "сорбитол" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "ManufacturerAddress", "ManufacturerName" },
                values: new object[,]
                {
                    { 1, 1, "Address, address", "NikaPharm" },
                    { 2, 2, "Address, address", "Gedeon" },
                    { 3, 3, "Address, address", "GSK" },
                    { 4, 3, "Address, address", "Novartis" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "ImageUrl", "InterName", "ManufacturerId", "MedformId", "TradeName" },
                values: new object[,]
                {
                    { 1, "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg", "Ekvator", 1, 2, "Экватор" },
                    { 2, "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg", "Paracetamol", 2, 1, "Парацетамол" },
                    { 3, "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg", "Trimol", 1, 2, "Тримол" },
                    { 4, "https://catalog.milliykatalogi.uz/s3/300x200/d907d480-1123-7c71-e0df-3d981a6960ff.jpg", "Acvad", 1, 2, "Аквад" }
                });

            migrationBuilder.InsertData(
                table: "DoseMedicines",
                columns: new[] { "DoseId", "MedicineId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "MedicineSubstances",
                columns: new[] { "MedicineId", "SubstanceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryName",
                table: "Countries",
                column: "CountryName",
                unique: true,
                filter: "[CountryName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoseMedicines_MedicineId",
                table: "DoseMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_CountryId",
                table: "Manufacturers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_ManufacturerName",
                table: "Manufacturers",
                column: "ManufacturerName",
                unique: true,
                filter: "[ManufacturerName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ManufacturerId",
                table: "Medicines",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedformId",
                table: "Medicines",
                column: "MedformId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineSubstances_SubstanceId",
                table: "MedicineSubstances",
                column: "SubstanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoseMedicines");

            migrationBuilder.DropTable(
                name: "MedicineSubstances");

            migrationBuilder.DropTable(
                name: "Doses");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Substances");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Medforms");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
