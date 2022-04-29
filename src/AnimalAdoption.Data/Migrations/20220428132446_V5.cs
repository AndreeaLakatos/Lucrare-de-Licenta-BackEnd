using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d205a51-c2b7-4ebf-8c4f-27167188a5c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bcc9ecb-bf3e-4813-bc17-896b761ac8da");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "068c86ca-956d-4302-afc8-63e1f3573d43", "06bcb8b5-e2f9-4a75-ad0d-519834dd27d2", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5aaf54b6-5a05-4512-8333-1268693d934e", "7fb9ff7b-9b80-41bd-ad5c-f3020257d4a8", "Ngo", "NGO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068c86ca-956d-4302-afc8-63e1f3573d43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5aaf54b6-5a05-4512-8333-1268693d934e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7bcc9ecb-bf3e-4813-bc17-896b761ac8da", "39821b48-061b-40c2-b372-c42961c7fc8a", "BasicUser", "BASICUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d205a51-c2b7-4ebf-8c4f-27167188a5c6", "62de60cc-6d46-4732-a6c2-ad9fde5c9c2c", "Ngo", "NGO" });
        }
    }
}
