using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Simantri.Migrations
{
    public partial class Migrate_20191022_171307 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Key = table.Column<string>(maxLength: 20, nullable: false),
                    Value = table.Column<string>(maxLength: 255, nullable: false, defaultValue: "Not defined yet."),
                    IsActive = table.Column<short>(type: "bit", nullable: false, defaultValue: (short)1),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UIX_Config_Key",
                table: "Config",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Config");
        }
    }
}
