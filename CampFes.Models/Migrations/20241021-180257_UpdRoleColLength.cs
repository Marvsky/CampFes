using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdRoleColLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                table: "AllUsers",
                type: "varchar(20)",
                nullable: true,
                comment: "權限角色",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true,
                oldComment: "權限角色");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                table: "AllUsers",
                type: "varchar(10)",
                nullable: true,
                comment: "權限角色",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true,
                oldComment: "權限角色");
        }
    }
}
