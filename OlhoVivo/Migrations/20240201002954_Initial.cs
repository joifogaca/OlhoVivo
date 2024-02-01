using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlhoVivo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusStops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lines_BusStop",
                columns: table => new
                {
                    BusStopId = table.Column<long>(type: "bigint", nullable: false),
                    FKBusStopLineLineId = table.Column<long>(name: "FK_BusStopLine_LineId", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines_BusStop", x => new { x.BusStopId, x.FKBusStopLineLineId });
                    table.ForeignKey(
                        name: "FK_BusStopLine_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lines_BusStop_Lines_FK_BusStopLine_LineId",
                        column: x => x.FKBusStopLineLineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    LineId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VEHICLE_LINE",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PositionVehicles",
                columns: table => new
                {
                    DateTime = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValue: new DateTime(2024, 2, 1, 0, 29, 54, 470, DateTimeKind.Utc).AddTicks(3858)),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionVehicles", x => new { x.DateTime, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_VEHICLE_POSITIONS",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BUSSTOP_NAME",
                table: "BusStops",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lINE_NAME",
                table: "Lines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lines_BusStop_FK_BusStopLine_LineId",
                table: "Lines_BusStop",
                column: "FK_BusStopLine_LineId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionVehicles_VehicleId",
                table: "PositionVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_NAME",
                table: "Vehicles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LineId",
                table: "Vehicles",
                column: "LineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lines_BusStop");

            migrationBuilder.DropTable(
                name: "PositionVehicles");

            migrationBuilder.DropTable(
                name: "BusStops");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Lines");
        }
    }
}
