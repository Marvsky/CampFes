using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdALLUserColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UNI_QRCODE",
                table: "AllUsers",
                type: "varchar(8)",
                nullable: true,
                defaultValueSql: "LEFT(NEWID(), 8)", // 使用 NEWID() 生成 GUID 並取前 8 個字元
                comment: "電子身分證",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true,
                oldComment: "電子身分證");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UNI_QRCODE",
                table: "AllUsers",
                type: "varchar(max)",
                nullable: true,
                comment: "電子身分證",
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true,
                oldComment: "電子身分證");
        }
    }
}
