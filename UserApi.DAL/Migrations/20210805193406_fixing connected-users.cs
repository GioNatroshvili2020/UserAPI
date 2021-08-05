using Microsoft.EntityFrameworkCore.Migrations;

namespace UserApi.DAL.Migrations
{
    public partial class fixingconnectedusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedPeople_Person_PersonId",
                table: "ConnectedPeople");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "ConnectedPeople",
                newName: "PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_ConnectedPeople_PersonId",
                table: "ConnectedPeople",
                newName: "IX_ConnectedPeople_PersonID");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "ConnectedPeople",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConnectedPersonId",
                table: "ConnectedPeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedPeople_Person_PersonID",
                table: "ConnectedPeople",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectedPeople_Person_PersonID",
                table: "ConnectedPeople");

            migrationBuilder.DropColumn(
                name: "ConnectedPersonId",
                table: "ConnectedPeople");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "ConnectedPeople",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ConnectedPeople_PersonID",
                table: "ConnectedPeople",
                newName: "IX_ConnectedPeople_PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "ConnectedPeople",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectedPeople_Person_PersonId",
                table: "ConnectedPeople",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
