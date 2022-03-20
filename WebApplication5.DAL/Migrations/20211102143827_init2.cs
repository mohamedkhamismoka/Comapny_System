using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication5.DAL.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creationdate",
                table: "employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Hiredate",
                table: "employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "phone",
                table: "employees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creationdate",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Hiredate",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "address",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "name",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "employees");
        }
    }
}
