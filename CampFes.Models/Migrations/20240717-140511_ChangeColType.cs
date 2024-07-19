using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampFes.Models.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropColumn(
                name: "CID",
                table: "QuestHistory");

            migrationBuilder.AddColumn<int>(
                name: "CID",
                table: "QuestHistory",
                type: "int",
                nullable: false,
                comment: "QRCODE CID");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckPoint",
                table: "CheckPoint");

            migrationBuilder.DropColumn(
                name: "CID",
                table: "CheckPoint");

            migrationBuilder.AddColumn<int>(
                name: "CID",
                table: "CheckPoint",
                type: "int",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckPoint",
                table: "CheckPoint",
                column: "CID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CID",
                table: "QuestHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "CID",
                table: "QuestHistory",
                type: "uniqueidentifier",
                nullable: false,
                comment: "QRCODE CID");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckPoint",
                table: "CheckPoint");

            migrationBuilder.DropColumn(
                name: "CID",
                table: "CheckPoint");

            migrationBuilder.AddColumn<Guid>(
                name: "CID",
                table: "CheckPoint",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
               name: "PK_CheckPoint",
               table: "CheckPoint",
               column: "CID");

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
    }
}
