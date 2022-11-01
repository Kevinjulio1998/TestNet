using Microsoft.EntityFrameworkCore.Migrations;

namespace Dummy.Infrastructure.Migrations
{
    public partial class addlogvalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "LogContact",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "LogContact");
        }
    }
}
