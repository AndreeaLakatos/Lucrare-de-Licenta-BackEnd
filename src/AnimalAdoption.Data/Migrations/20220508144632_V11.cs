using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d9b0c54-42cd-422a-946f-fda045ccfc72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e17198-0963-4df7-b1df-ad96f4e9e516");

            migrationBuilder.AddColumn<bool>(
                name: "Reviewed",
                table: "FosteringRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Reviewed",
                table: "AdoptionRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15ef093c-5988-4884-bd28-927bdcbc7eb2", "17d5eabd-c43c-40ff-a3cb-51f051ac9882", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f4bda68-37cf-43f6-a159-3a21e02bce5d", "05dfa0bd-6047-48d1-8cb9-63fa032b7776", "Ngo", "NGO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15ef093c-5988-4884-bd28-927bdcbc7eb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4bda68-37cf-43f6-a159-3a21e02bce5d");

            migrationBuilder.DropColumn(
                name: "Reviewed",
                table: "FosteringRequests");

            migrationBuilder.DropColumn(
                name: "Reviewed",
                table: "AdoptionRequests");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d9b0c54-42cd-422a-946f-fda045ccfc72", "208dae2f-8111-4a50-a631-7ee3c09a6fe6", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87e17198-0963-4df7-b1df-ad96f4e9e516", "fe6116d1-c002-4f05-bfca-dd76b188893d", "Ngo", "NGO" });
        }
    }
}
