using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_SqlTblDep_Infrastructure.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EyeColor",
                columns: new[] { "Id", "Color" },
                values: new object[,]
                {
                    { new Guid("a401d4e4-fe28-49ba-ac27-f9c76511c4d6"), "Brown" },
                    { new Guid("56b7f17c-ede7-4575-9ad6-2176b393a8ab"), "Blue" },
                    { new Guid("c783ac59-b34b-47e1-afcc-5716dd2777ef"), "Grey" },
                    { new Guid("dfdfd891-3df5-469c-9f9d-84ab856c23cc"), "Yello" },
                    { new Guid("ec2cc6fc-5afb-4300-b07b-4af521e02093"), "Red" },
                    { new Guid("0f51c023-a503-49c8-8bf5-e123f7831133"), "Green" },
                    { new Guid("5b3ca54c-4ae5-4bc5-9d65-0d1197844498"), "Pink" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("0f51c023-a503-49c8-8bf5-e123f7831133"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("56b7f17c-ede7-4575-9ad6-2176b393a8ab"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("5b3ca54c-4ae5-4bc5-9d65-0d1197844498"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("a401d4e4-fe28-49ba-ac27-f9c76511c4d6"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("c783ac59-b34b-47e1-afcc-5716dd2777ef"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("dfdfd891-3df5-469c-9f9d-84ab856c23cc"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("ec2cc6fc-5afb-4300-b07b-4af521e02093"));
        }
    }
}
