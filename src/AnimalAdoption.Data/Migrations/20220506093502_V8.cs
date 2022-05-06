using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9982ef8f-acd3-4b4a-aec4-cdda08c12240");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba767df1-d0cb-4e65-a2ed-70d87e880f44");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FosteringRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FosteringAnnouncements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AdoptionRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AdoptionAnnouncements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51473ca0-36de-487d-ae91-7c325c09e72d", "f1f8c950-90ce-438b-918b-65a2c54f1fa7", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd75d055-ee61-4673-bb44-945d2e9547a4", "d4c0d46e-dd19-4a78-88ac-97ec6976b17c", "Ngo", "NGO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51473ca0-36de-487d-ae91-7c325c09e72d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd75d055-ee61-4673-bb44-945d2e9547a4");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FosteringRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FosteringAnnouncements");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AdoptionAnnouncements");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba767df1-d0cb-4e65-a2ed-70d87e880f44", "d07e811a-76e6-4fbe-af60-6ec99892129e", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9982ef8f-acd3-4b4a-aec4-cdda08c12240", "2f5ac023-a750-4836-b2f0-a6cd340d252d", "Ngo", "NGO" });
        }
    }
}
