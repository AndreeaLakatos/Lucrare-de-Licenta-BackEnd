using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "458f8460-109d-40ec-94d5-54dd6b637595");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa076f1-fbbe-4cde-9329-0e91391c8e3e");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "FosteringRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AdoptionRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d9b0c54-42cd-422a-946f-fda045ccfc72", "208dae2f-8111-4a50-a631-7ee3c09a6fe6", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87e17198-0963-4df7-b1df-ad96f4e9e516", "fe6116d1-c002-4f05-bfca-dd76b188893d", "Ngo", "NGO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d9b0c54-42cd-422a-946f-fda045ccfc72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e17198-0963-4df7-b1df-ad96f4e9e516");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "FosteringRequests");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AdoptionRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aa076f1-fbbe-4cde-9329-0e91391c8e3e", "684ab5ea-4c5a-430a-bf0b-ba93f006b4da", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "458f8460-109d-40ec-94d5-54dd6b637595", "ea8d442e-91c0-498d-8984-f11264ff58d9", "Ngo", "NGO" });
        }
    }
}
