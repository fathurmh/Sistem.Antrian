using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simantri.Migrations
{
    public partial class Migrate_20191022_171653 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Config");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Config",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
