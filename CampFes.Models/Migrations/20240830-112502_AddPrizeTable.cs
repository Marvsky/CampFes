using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddPrizeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PID",
                table: "EasyUser",
                type: "int",
                nullable: true,
                comment: "闖關獎品編號",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "闖關獎品編號");

            migrationBuilder.CreateTable(
                name: "Prize",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GRADING = table.Column<string>(type: "varchar(1)", nullable: false, comment: "等級"),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "說明"),
                    QUANTITY = table.Column<int>(type: "int", nullable: false, comment: "數量"),
                    REMARK = table.Column<string>(type: "nvarchar(200)", nullable: true, comment: "備註")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prize", x => x.PID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prize");

            migrationBuilder.AlterColumn<int>(
                name: "PID",
                table: "EasyUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "闖關獎品編號",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "闖關獎品編號");
        }
    }
}
