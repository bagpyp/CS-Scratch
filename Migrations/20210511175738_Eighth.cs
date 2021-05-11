using Microsoft.EntityFrameworkCore.Migrations;

namespace Scratch.Migrations
{
    public partial class Eighth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "OtherPersonId",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons",
                column: "OtherPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "OtherPersonId",
                table: "Persons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_OtherPersonId",
                table: "Persons",
                column: "OtherPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
