using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_TIME",
                table: "Registration",
                type: "datetime",
                nullable: true,
                comment: "更新時間",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComment: "更新時間");

            migrationBuilder.AlterColumn<string>(
                name: "IS_RECIEVED",
                table: "Registration",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "N",
                comment: "領取紀錄",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldComment: "領取紀錄");

            migrationBuilder.AlterColumn<string>(
                name: "IS_STAFF",
                table: "AllowPlayer",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "N",
                comment: "是否是工作人員",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldComment: "是否是工作人員");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UPDATE_TIME",
                table: "Registration",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "更新時間",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldComment: "更新時間");

            migrationBuilder.AlterColumn<string>(
                name: "IS_RECIEVED",
                table: "Registration",
                type: "varchar(1)",
                nullable: false,
                comment: "領取紀錄",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldDefaultValue: "N",
                oldComment: "領取紀錄");

            migrationBuilder.AlterColumn<string>(
                name: "IS_STAFF",
                table: "AllowPlayer",
                type: "varchar(1)",
                nullable: false,
                comment: "是否是工作人員",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldDefaultValue: "N",
                oldComment: "是否是工作人員");
        }
    }
}
