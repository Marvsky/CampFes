using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class AddAllUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('dbo.Prize', 'U') IS NOT NULL DROP TABLE dbo.Prize");

            migrationBuilder.CreateTable(
                name: "AllUsers",
                columns: table => new
                {
                    CHECKER = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "報到代表人"),
                    NICK_NAME = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "暱稱"),
                    AREA = table.Column<string>(type: "varchar(10)", nullable: true, comment: "營位"),
                    ROLE = table.Column<string>(type: "varchar(10)", nullable: true, comment: "權限角色")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Prize",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.DropTable(
                name: "AllUsers");
        }
    }
}
