using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class CancelIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QID",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QID",
                table: "Question",
                type: "int",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QID");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyUser",
                table: "EasyUser");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "EasyUser");

            migrationBuilder.AddColumn<int>(
                name: "UID",
                table: "EasyUser",
                type: "int",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyUser",
                table: "EasyUser",
                column: "UID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QID",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyUser",
                table: "EasyUser");

            migrationBuilder.DropColumn(
                name: "UID",
                table: "EasyUser");
        }
    }
}
