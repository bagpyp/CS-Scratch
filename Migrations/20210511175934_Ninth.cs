using Microsoft.EntityFrameworkCore.Migrations;

namespace Scratch.Migrations
{
    public partial class Ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons",
                column: "OtherPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons",
                column: "OtherPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
