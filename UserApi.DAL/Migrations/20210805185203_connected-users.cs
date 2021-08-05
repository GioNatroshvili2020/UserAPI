using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApi.DAL.Migrations
{
    public partial class connectedusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_PersonID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "ConnectedPeople",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ConnectionType = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectedPeople", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConnectedPeople_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedPeople_PersonId",
                table: "ConnectedPeople",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectedPeople");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonID",
                table: "Person",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_PersonID",
                table: "Person",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
