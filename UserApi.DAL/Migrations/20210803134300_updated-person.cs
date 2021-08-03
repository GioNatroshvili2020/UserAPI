using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApi.DAL.Migrations
{
    public partial class updatedperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_PersonId",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Person",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Person_PersonId",
                table: "Person",
                newName: "IX_Person_PersonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "ID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "City",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "City",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "City",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_PersonID",
                table: "Person",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_PersonID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "City");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "City");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Person",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Person_PersonID",
                table: "Person",
                newName: "IX_Person_PersonId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "City",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_PersonId",
                table: "Person",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
