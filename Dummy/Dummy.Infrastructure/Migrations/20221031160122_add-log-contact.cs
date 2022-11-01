using Microsoft.EntityFrameworkCore.Migrations;

namespace Dummy.Infrastructure.Migrations
{
    public partial class addlogcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "ContactInformation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LogContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTypeContact = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogContact", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogContact");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "ContactInformation");
        }
    }
}
