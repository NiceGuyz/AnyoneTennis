using Microsoft.EntityFrameworkCore.Migrations;

namespace AnyoneTennis.Migrations
{
    public partial class DeleteEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "email", table: "member");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "email", table: "member", nullable: true);
        }
    }
}
