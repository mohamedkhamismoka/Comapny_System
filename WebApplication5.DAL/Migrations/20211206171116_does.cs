using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication5.DAL.Migrations
{
    public partial class does : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dnum",
                table: "works",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dnum",
                table: "works");
        }
    }
}
