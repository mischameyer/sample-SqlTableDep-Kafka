using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_SqlTblDep_Infrastructure.Migrations
{
    public partial class setupnewentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BigFoot",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    FootSize = table.Column<decimal>(nullable: false),
                    EyeColor = table.Column<Guid>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Mom = table.Column<Guid>(nullable: false),
                    Daddy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BigFoot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EyeColor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeColor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BigFoot");

            migrationBuilder.DropTable(
                name: "EyeColor");
        }
    }
}
