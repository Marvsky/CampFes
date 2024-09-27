using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddUserColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FINGERPRINT",
                table: "EasyUser",
                type: "varchar(max)",
                nullable: false,
                comment: "手機指紋",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldComment: "指紋");

            migrationBuilder.AddColumn<string>(
                name: "IS_RECIEVED",
                table: "EasyUser",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "",
                comment: "領取紀錄");

            migrationBuilder.AddColumn<int>(
                name: "PID",
                table: "EasyUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "闖關獎品編號");

            migrationBuilder.AddColumn<string>(
                name: "UNI_QRCODE",
                table: "AllowPlayer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "電子身分證");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_RECIEVED",
                table: "EasyUser");

            migrationBuilder.DropColumn(
                name: "PID",
                table: "EasyUser");

            migrationBuilder.DropColumn(
                name: "UNI_QRCODE",
                table: "AllowPlayer");

            migrationBuilder.AlterColumn<string>(
                name: "FINGERPRINT",
                table: "EasyUser",
                type: "varchar(max)",
                nullable: false,
                comment: "指紋",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldComment: "手機指紋");
        }
    }
}
