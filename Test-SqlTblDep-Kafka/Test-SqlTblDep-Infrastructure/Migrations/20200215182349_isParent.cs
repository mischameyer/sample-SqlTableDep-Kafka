using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test_SqlTblDep_Infrastructure.Migrations
{
    public partial class isParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "isParent",
                table: "BigFoot",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "EyeColor",
                columns: new[] { "Id", "Color" },
                values: new object[,]
                {
                    { new Guid("5aadc7f7-6acd-4c72-a221-f5180bcf3ed5"), "Brown" },
                    { new Guid("7aeb2e86-9141-48fd-a744-1ace00726d94"), "Blue" },
                    { new Guid("64bc5be1-b86b-4e63-b97a-fd5e6b87d755"), "Grey" },
                    { new Guid("7aaea121-6c7c-43b5-9cba-0a5a315ed1f7"), "Yello" },
                    { new Guid("ebe53431-ebca-4c3e-9f93-3f66fefdbb91"), "Red" },
                    { new Guid("98f3302d-d501-4de3-a093-65a92487fc1b"), "Green" },
                    { new Guid("4931e4f7-fbb1-41f1-a5ce-384bc55617ca"), "Pink" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("4931e4f7-fbb1-41f1-a5ce-384bc55617ca"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("5aadc7f7-6acd-4c72-a221-f5180bcf3ed5"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("64bc5be1-b86b-4e63-b97a-fd5e6b87d755"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("7aaea121-6c7c-43b5-9cba-0a5a315ed1f7"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("7aeb2e86-9141-48fd-a744-1ace00726d94"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("98f3302d-d501-4de3-a093-65a92487fc1b"));

            migrationBuilder.DeleteData(
                table: "EyeColor",
                keyColumn: "Id",
                keyValue: new Guid("ebe53431-ebca-4c3e-9f93-3f66fefdbb91"));

            migrationBuilder.DropColumn(
                name: "isParent",
                table: "BigFoot");

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
    }
}
