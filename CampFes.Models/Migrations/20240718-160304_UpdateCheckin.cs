using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCheckin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AREA",
                table: "Registration",
                type: "varchar(10)",
                nullable: true,
                comment: "營位");

            migrationBuilder.AddColumn<string>(
                name: "CHECKER",
                table: "Registration",
                type: "nvarchar(20)",
                nullable: true,
                comment: "實際報到人");

            migrationBuilder.AddColumn<string>(
                name: "PHONES",
                table: "Registration",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "",
                comment: "報到人手機(可多組)");

            migrationBuilder.AddColumn<string>(
                name: "REMARK",
                table: "Registration",
                type: "nvarchar(200)",
                nullable: true,
                comment: "備註");

            migrationBuilder.AlterColumn<string>(
                name: "REMARK",
                table: "AllowPlayer",
                type: "nvarchar(100)",
                nullable: true,
                comment: "備註",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldComment: "備註");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AREA",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "CHECKER",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "PHONES",
                table: "Registration");

            migrationBuilder.DropColumn(
                name: "REMARK",
                table: "Registration");

            migrationBuilder.AlterColumn<string>(
                name: "REMARK",
                table: "AllowPlayer",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                comment: "備註",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true,
                oldComment: "備註");
        }
    }
}
