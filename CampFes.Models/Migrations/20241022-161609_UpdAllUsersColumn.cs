using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdAllUsersColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GROUPNO",
                table: "AllUsers",
                type: "int",
                nullable: true,
                comment: "報名序號",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "報名序號");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GROUPNO",
                table: "AllUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "報名序號",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "報名序號");
        }
    }
}
