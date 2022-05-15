using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e7cf9fa-91f7-4a16-8d62-006b1721f1ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "843ee3f6-f195-4949-aeff-248dd44d152a");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hour",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65629139-3935-419c-ba99-5fa65861a79e", "f498b6d3-b897-4c92-b0c6-233188977726", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4661ad4-b57d-451e-8c1a-eb40175ba557", "1e75be16-d1b8-4818-bf2c-e84d79526355", "Ngo", "NGO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65629139-3935-419c-ba99-5fa65861a79e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4661ad4-b57d-451e-8c1a-eb40175ba557");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Notifications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "843ee3f6-f195-4949-aeff-248dd44d152a", "1d8ae539-985e-4a00-8451-b9ba1e749f0f", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e7cf9fa-91f7-4a16-8d62-006b1721f1ad", "8499d1b5-be8e-4722-b103-7338022223e5", "Ngo", "NGO" });
        }
    }
}
