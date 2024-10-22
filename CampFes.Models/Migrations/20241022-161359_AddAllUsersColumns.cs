using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddAllUsersColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GROUPNO",
                table: "AllUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "報名序號");

            migrationBuilder.AddColumn<int>(
                name: "SNO",
                table: "AllUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "序號");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GROUPNO",
                table: "AllUsers");

            migrationBuilder.DropColumn(
                name: "SNO",
                table: "AllUsers");
        }
    }
}
