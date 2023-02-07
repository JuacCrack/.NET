using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class nullupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Cities_CityFK",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "CityFK",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Cities_CityFK",
                table: "Contacts",
                column: "CityFK",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Cities_CityFK",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "CityFK",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Cities_CityFK",
                table: "Contacts",
                column: "CityFK",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
