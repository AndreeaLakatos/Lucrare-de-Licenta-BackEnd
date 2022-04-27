using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27dd6f7c-efab-43ed-9e42-4f2131f68896");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d8323c9-c336-41bc-8dd6-464a647841d4");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdoptionAnnouncementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AdoptionAnnouncements_AdoptionAnnouncementId",
                        column: x => x.AdoptionAnnouncementId,
                        principalTable: "AdoptionAnnouncements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7bcc9ecb-bf3e-4813-bc17-896b761ac8da", "39821b48-061b-40c2-b372-c42961c7fc8a", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d205a51-c2b7-4ebf-8c4f-27167188a5c6", "62de60cc-6d46-4732-a6c2-ad9fde5c9c2c", "Ngo", "NGO" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AdoptionAnnouncementId",
                table: "Photos",
                column: "AdoptionAnnouncementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d205a51-c2b7-4ebf-8c4f-27167188a5c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bcc9ecb-bf3e-4813-bc17-896b761ac8da");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptionAnnouncementId = table.Column<int>(type: "int", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AdoptionAnnouncements_AdoptionAnnouncementId",
                        column: x => x.AdoptionAnnouncementId,
                        principalTable: "AdoptionAnnouncements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27dd6f7c-efab-43ed-9e42-4f2131f68896", "852490e4-2c00-401a-ba6a-0a5aa97f076a", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d8323c9-c336-41bc-8dd6-464a647841d4", "10a71d9a-5543-47cb-ab06-7281cf260777", "Ngo", "NGO" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdoptionAnnouncementId",
                table: "Images",
                column: "AdoptionAnnouncementId");
        }
    }
}
