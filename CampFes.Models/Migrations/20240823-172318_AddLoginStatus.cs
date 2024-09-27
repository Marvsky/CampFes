using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddLoginStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IS_RECIEVED",
                table: "EasyUser",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "N",
                comment: "領取紀錄",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldComment: "領取紀錄");

            migrationBuilder.AddColumn<string>(
                name: "IS_LOGIN",
                table: "EasyUser",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "N",
                comment: "是否登入中");

            migrationBuilder.AddColumn<string>(
                name: "UNI_QRCODE",
                table: "EasyUser",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "電子身分證");

            migrationBuilder.AlterColumn<string>(
                name: "UNI_QRCODE",
                table: "AllowPlayer",
                type: "varchar(max)",
                nullable: false,
                comment: "電子身分證",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "電子身分證");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_LOGIN",
                table: "EasyUser");

            migrationBuilder.DropColumn(
                name: "UNI_QRCODE",
                table: "EasyUser");

            migrationBuilder.AlterColumn<string>(
                name: "IS_RECIEVED",
                table: "EasyUser",
                type: "varchar(1)",
                nullable: false,
                comment: "領取紀錄",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldDefaultValue: "N",
                oldComment: "領取紀錄");

            migrationBuilder.AlterColumn<string>(
                name: "UNI_QRCODE",
                table: "AllowPlayer",
                type: "nvarchar(max)",
                nullable: false,
                comment: "電子身分證",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldComment: "電子身分證");
        }
    }
}
