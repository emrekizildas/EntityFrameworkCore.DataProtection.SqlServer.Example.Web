using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.DataProtection.Example.Web.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EncryptExamples",
                columns: table => new
                {
                    UUID = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    EncryptArea = table.Column<string>(nullable: true),
                    CleanArea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncryptExamples", x => x.UUID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncryptExamples");
        }
    }
}
