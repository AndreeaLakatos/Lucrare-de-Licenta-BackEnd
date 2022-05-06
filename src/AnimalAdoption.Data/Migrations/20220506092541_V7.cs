using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FosterApplications");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ab29b8c-3281-48bc-a722-3fe82fd93d82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f52229-6aab-4735-b616-6781c6fe38c6");

            migrationBuilder.CreateTable(
                name: "AdoptionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SomethingElse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdoptionAnnouncementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionRequests_AdoptionAnnouncements_AdoptionAnnouncementId",
                        column: x => x.AdoptionAnnouncementId,
                        principalTable: "AdoptionAnnouncements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FosteringRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SomethingElse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FosteringAnnouncementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FosteringRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FosteringRequests_FosteringAnnouncements_FosteringAnnouncementId",
                        column: x => x.FosteringAnnouncementId,
                        principalTable: "FosteringAnnouncements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba767df1-d0cb-4e65-a2ed-70d87e880f44", "d07e811a-76e6-4fbe-af60-6ec99892129e", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9982ef8f-acd3-4b4a-aec4-cdda08c12240", "2f5ac023-a750-4836-b2f0-a6cd340d252d", "Ngo", "NGO" });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_AdoptionAnnouncementId",
                table: "AdoptionRequests",
                column: "AdoptionAnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_FosteringRequests_FosteringAnnouncementId",
                table: "FosteringRequests",
                column: "FosteringAnnouncementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionRequests");

            migrationBuilder.DropTable(
                name: "FosteringRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9982ef8f-acd3-4b4a-aec4-cdda08c12240");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba767df1-d0cb-4e65-a2ed-70d87e880f44");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalSize = table.Column<int>(type: "int", nullable: false),
                    AnimalType = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_AspNetUsers_NgoId",
                        column: x => x.NgoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FosterApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementId = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdopted = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FosterApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FosterApplications_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1ab29b8c-3281-48bc-a722-3fe82fd93d82", "a7b14f7d-fd15-4eda-949f-aea443826054", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2f52229-6aab-4735-b616-6781c6fe38c6", "0c64627f-840f-4371-950e-c9a3a6da1f7d", "Ngo", "NGO" });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AnimalId",
                table: "Advertisements",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_NgoId",
                table: "Animals",
                column: "NgoId");

            migrationBuilder.CreateIndex(
                name: "IX_FosterApplications_AdvertisementId",
                table: "FosterApplications",
                column: "AdvertisementId");
        }
    }
}
