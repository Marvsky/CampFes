using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllowPlayer",
                columns: table => new
                {
                    NICK_NAME = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "暱稱"),
                    REMARK = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "備註"),
                    IS_STAFF = table.Column<string>(type: "varchar(1)", nullable: false, comment: "是否是工作人員")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CheckPoint",
                columns: table => new
                {
                    CID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "名稱"),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "說明"),
                    QRCODE = table.Column<string>(type: "varchar(max)", nullable: false, comment: "QRCODE條碼"),
                    QFLAG = table.Column<int>(type: "int", nullable: false, comment: "大地遊戲用為1 否則為0"),
                    CREATE_TIME = table.Column<DateTime>(type: "datetime", nullable: false, comment: "建立時間"),
                    UPDATE_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "更新時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckPoint", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "EasyUser",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NICK_NAME = table.Column<string>(type: "nvarchar(100)", nullable: false, comment: "暱稱"),
                    FINGERPRINT = table.Column<string>(type: "varchar(max)", nullable: false, comment: "指紋"),
                    REMARK = table.Column<string>(type: "nvarchar(100)", nullable: true, comment: "備註"),
                    ROLE = table.Column<string>(type: "varchar(10)", nullable: true, comment: "權限角色"),
                    CREATE_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "建立時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyUser", x => x.UID);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MACHINE_NAME = table.Column<string>(type: "varchar(100)", nullable: true),
                    TIMESTAMP = table.Column<string>(type: "varchar(50)", nullable: true),
                    LOGLEVEL = table.Column<string>(type: "varchar(50)", nullable: true),
                    LOGGER = table.Column<string>(type: "varchar(100)", nullable: true),
                    CALLSITE = table.Column<string>(type: "varchar(max)", nullable: true),
                    MESSAGE = table.Column<string>(type: "varchar(max)", nullable: true),
                    EXCETION = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuestHistory",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false, comment: "用戶 UID"),
                    QNO = table.Column<int>(type: "int", nullable: false, comment: "問題序號1~10"),
                    CID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "QRCODE CID"),
                    QID = table.Column<int>(type: "int", nullable: false, comment: "題目 QID"),
                    ANSWER = table.Column<string>(type: "varchar(4)", nullable: true, comment: "答題"),
                    START_TIME = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GETDATE()", comment: "答題起始時間"),
                    END_TIME = table.Column<DateTime>(type: "datetime", nullable: true, comment: "答題結束時間"),
                    SPEND_SECONDS = table.Column<int>(type: "int", nullable: true, comment: "耗費秒數")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestHistory", x => new { x.UID, x.QNO });
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUESTION = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "問題"),
                    IS_MULTI = table.Column<string>(type: "varchar(1)", nullable: false, comment: "是否為複選題"),
                    OPTION_A = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "選項A"),
                    OPTION_B = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "選項B"),
                    OPTION_C = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "選項C"),
                    OPTION_D = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "選項D"),
                    CORRECT = table.Column<string>(type: "varchar(4)", nullable: false, comment: "答案"),
                    HINT = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "提示"),
                    AUTHOR = table.Column<string>(type: "nvarchar(20)", nullable: true, comment: "出題者"),
                    IS_USE = table.Column<string>(type: "varchar(1)", nullable: true, comment: "是否採用")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QID);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    NICK_NAMES = table.Column<string>(type: "nvarchar(MAX)", nullable: false, comment: "報到人暱稱(可多人)"),
                    ITEMS = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "領取品"),
                    IS_RECIEVED = table.Column<string>(type: "varchar(1)", nullable: false, comment: "領取紀錄"),
                    UPDATE_TIME = table.Column<DateTime>(type: "datetime", nullable: false, comment: "更新時間")
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ROLE = table.Column<string>(type: "varchar(20)", nullable: false, comment: "角色"),
                    NAME = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "名稱"),
                    LEVEL = table.Column<int>(type: "int", nullable: false, comment: "權限等級")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ROLE);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    STAFFNAME = table.Column<string>(type: "nvarchar(20)", nullable: false, comment: "幹部暱稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.STAFFNAME);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowPlayer");

            migrationBuilder.DropTable(
                name: "CheckPoint");

            migrationBuilder.DropTable(
                name: "EasyUser");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "QuestHistory");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
