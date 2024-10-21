using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddAllUserColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UNI_QRCODE",
                table: "AllUsers",
                type: "varchar(max)",
                nullable: true,
                comment: "電子身分證");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UNI_QRCODE",
                table: "AllUsers");
        }
    }
}
