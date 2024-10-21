using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HAS_PRIZE",
                table: "Role",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "N",
                comment: "是否有參加獎");

            migrationBuilder.AlterColumn<string>(
                name: "IS_LOGIN",
                table: "EasyUser",
                type: "varchar(1)",
                nullable: true,
                defaultValue: "N",
                comment: "是否登入中",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldDefaultValue: "N",
                oldComment: "是否登入中");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HAS_PRIZE",
                table: "Role");

            migrationBuilder.AlterColumn<string>(
                name: "IS_LOGIN",
                table: "EasyUser",
                type: "varchar(1)",
                nullable: false,
                defaultValue: "N",
                comment: "是否登入中",
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true,
                oldDefaultValue: "N",
                oldComment: "是否登入中");
        }
    }
}
