using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65629139-3935-419c-ba99-5fa65861a79e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4661ad4-b57d-451e-8c1a-eb40175ba557");

            migrationBuilder.AddColumn<string>(
                name: "FromDate",
                table: "FosteringRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromDate",
                table: "FosteringAnnouncements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromDate",
                table: "AdoptionRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromDate",
                table: "AdoptionAnnouncements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0d45f3b4-78c1-415f-840c-78850dc5ee8b", "31daae7f-1e8e-45b1-8a83-960521e1849d", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "451a4914-4eec-4250-988e-6cfb066320bd", "cf2612a7-fc7f-4008-8dd4-e0f9747b864f", "Ngo", "NGO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d45f3b4-78c1-415f-840c-78850dc5ee8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "451a4914-4eec-4250-988e-6cfb066320bd");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "FosteringRequests");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "FosteringAnnouncements");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "AdoptionAnnouncements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "65629139-3935-419c-ba99-5fa65861a79e", "f498b6d3-b897-4c92-b0c6-233188977726", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4661ad4-b57d-451e-8c1a-eb40175ba557", "1e75be16-d1b8-4818-bf2c-e84d79526355", "Ngo", "NGO" });
        }
    }
}
