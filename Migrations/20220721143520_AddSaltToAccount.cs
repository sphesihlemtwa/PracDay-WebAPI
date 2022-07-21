using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracDay_WebAPI.Migrations
{
    public partial class AddSaltToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "salt",
                table: "Account",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "Account");
        }
    }
}
