using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068c86ca-956d-4302-afc8-63e1f3573d43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5aaf54b6-5a05-4512-8333-1268693d934e");

            migrationBuilder.AddColumn<int>(
                name: "FosteringAnnouncementId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FosteringAnnouncements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimalType = table.Column<int>(type: "int", nullable: false),
                    AnimalSize = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoreDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FosteringAnnouncements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FosteringAnnouncements_AspNetUsers_NgoId",
                        column: x => x.NgoId,
                        principalTable: "AspNetUsers",
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
                name: "IX_Photos_FosteringAnnouncementId",
                table: "Photos",
                column: "FosteringAnnouncementId");

            migrationBuilder.CreateIndex(
                name: "IX_FosteringAnnouncements_NgoId",
                table: "FosteringAnnouncements",
                column: "NgoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_FosteringAnnouncements_FosteringAnnouncementId",
                table: "Photos",
                column: "FosteringAnnouncementId",
                principalTable: "FosteringAnnouncements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_FosteringAnnouncements_FosteringAnnouncementId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "FosteringAnnouncements");

            migrationBuilder.DropIndex(
                name: "IX_Photos_FosteringAnnouncementId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ab29b8c-3281-48bc-a722-3fe82fd93d82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f52229-6aab-4735-b616-6781c6fe38c6");

            migrationBuilder.DropColumn(
                name: "FosteringAnnouncementId",
                table: "Photos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "068c86ca-956d-4302-afc8-63e1f3573d43", "06bcb8b5-e2f9-4a75-ad0d-519834dd27d2", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5aaf54b6-5a05-4512-8333-1268693d934e", "7fb9ff7b-9b80-41bd-ad5c-f3020257d4a8", "Ngo", "NGO" });
        }
    }
}
