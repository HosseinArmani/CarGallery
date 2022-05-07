using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.DataLayer.Migrations
{
    public partial class migCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBodyInformations",
                columns: table => new
                {
                    CarBodyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodyType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Weight = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DoorsCount = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodyInformations", x => x.CarBodyId);
                });

            migrationBuilder.CreateTable(
                name: "CarEngineInformations",
                columns: table => new
                {
                    CarEnginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineDisplacement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EngineType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    cylindersCount = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    SoupapeCount = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEngineInformations", x => x.CarEnginId);
                });

            migrationBuilder.CreateTable(
                name: "CarPrices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeCost = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    SalesPrice = table.Column<int>(type: "int", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPrices", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    CarBodyId = table.Column<int>(type: "int", nullable: false),
                    CarEngineId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_CarBodyInformations_CarBodyId",
                        column: x => x.CarBodyId,
                        principalTable: "CarBodyInformations",
                        principalColumn: "CarBodyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarEngineInformations_CarEngineId",
                        column: x => x.CarEngineId,
                        principalTable: "CarEngineInformations",
                        principalColumn: "CarEnginId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "CarGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_CarPrices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "CarPrices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarBodyId",
                table: "Cars",
                column: "CarBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarEngineId",
                table: "Cars",
                column: "CarEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GroupId",
                table: "Cars",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PriceId",
                table: "Cars",
                column: "PriceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarBodyInformations");

            migrationBuilder.DropTable(
                name: "CarEngineInformations");

            migrationBuilder.DropTable(
                name: "CarPrices");
        }
    }
}
