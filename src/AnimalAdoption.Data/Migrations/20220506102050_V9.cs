using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51473ca0-36de-487d-ae91-7c325c09e72d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd75d055-ee61-4673-bb44-945d2e9547a4");

            migrationBuilder.AddColumn<string>(
                name: "BasicUserId",
                table: "FosteringRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasicUserId",
                table: "AdoptionRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aa076f1-fbbe-4cde-9329-0e91391c8e3e", "684ab5ea-4c5a-430a-bf0b-ba93f006b4da", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "458f8460-109d-40ec-94d5-54dd6b637595", "ea8d442e-91c0-498d-8984-f11264ff58d9", "Ngo", "NGO" });

            migrationBuilder.CreateIndex(
                name: "IX_FosteringRequests_BasicUserId",
                table: "FosteringRequests",
                column: "BasicUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRequests_BasicUserId",
                table: "AdoptionRequests",
                column: "BasicUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_AspNetUsers_BasicUserId",
                table: "AdoptionRequests",
                column: "BasicUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FosteringRequests_AspNetUsers_BasicUserId",
                table: "FosteringRequests",
                column: "BasicUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_AspNetUsers_BasicUserId",
                table: "AdoptionRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FosteringRequests_AspNetUsers_BasicUserId",
                table: "FosteringRequests");

            migrationBuilder.DropIndex(
                name: "IX_FosteringRequests_BasicUserId",
                table: "FosteringRequests");

            migrationBuilder.DropIndex(
                name: "IX_AdoptionRequests_BasicUserId",
                table: "AdoptionRequests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "458f8460-109d-40ec-94d5-54dd6b637595");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa076f1-fbbe-4cde-9329-0e91391c8e3e");

            migrationBuilder.DropColumn(
                name: "BasicUserId",
                table: "FosteringRequests");

            migrationBuilder.DropColumn(
                name: "BasicUserId",
                table: "AdoptionRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51473ca0-36de-487d-ae91-7c325c09e72d", "f1f8c950-90ce-438b-918b-65a2c54f1fa7", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd75d055-ee61-4673-bb44-945d2e9547a4", "d4c0d46e-dd19-4a78-88ac-97ec6976b17c", "Ngo", "NGO" });
        }
    }
}
