using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAdoption.Data.Migrations
{
    public partial class UserMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserPreferencesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasFamily = table.Column<bool>(type: "bit", nullable: false),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false),
                    LivingPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimalSize = table.Column<int>(type: "int", nullable: false),
                    AnimalType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserPreferencesId",
                table: "AspNetUsers",
                column: "UserPreferencesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserPreferences_UserPreferencesId",
                table: "AspNetUsers",
                column: "UserPreferencesId",
                principalTable: "UserPreferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserPreferences_UserPreferencesId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserPreferencesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPreferencesId",
                table: "AspNetUsers");
        }
    }
}
