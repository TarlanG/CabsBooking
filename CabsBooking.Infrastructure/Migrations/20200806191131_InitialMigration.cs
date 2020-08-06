using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CabsBooking.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabTypes",
                columns: table => new
                {
                    CabTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabTypes", x => x.CabTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    BookingTime = table.Column<string>(type: "varchar(16)", nullable: false),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    PickUpAddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    LandMark = table.Column<string>(type: "varchar(30)", nullable: true),
                    PickupDate = table.Column<DateTime>(nullable: false),
                    PickupTime = table.Column<string>(type: "varchar(5)", nullable: false),
                    CabTypeId = table.Column<int>(nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(25)", nullable: false),
                    Status = table.Column<string>(type: "varchar(30)", nullable: true),
                    PlaceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_CabTypes_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    BookingTime = table.Column<string>(type: "varchar(16)", nullable: false),
                    FromPlace = table.Column<string>(nullable: true),
                    ToPlace = table.Column<string>(nullable: true),
                    PickUpAddress = table.Column<string>(type: "varchar(200)", nullable: true),
                    LandMark = table.Column<string>(type: "varchar(30)", nullable: true),
                    PickupDate = table.Column<DateTime>(nullable: false),
                    PickupTime = table.Column<string>(type: "varchar(5)", nullable: false),
                    CabTypeId = table.Column<int>(nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(25)", nullable: false),
                    Status = table.Column<string>(type: "varchar(30)", nullable: true),
                    PlaceId = table.Column<int>(nullable: true),
                    comp_time = table.Column<string>(type: "varchar(5)", nullable: true),
                    charge = table.Column<decimal>(nullable: false),
                    Feedback = table.Column<string>(type: "varchar(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingsHistory_CabTypes_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingsHistory_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CabTypeId",
                table: "Bookings",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PlaceId",
                table: "Bookings",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsHistory_CabTypeId",
                table: "BookingsHistory",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingsHistory_PlaceId",
                table: "BookingsHistory",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingsHistory");

            migrationBuilder.DropTable(
                name: "CabTypes");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}
