using Microsoft.EntityFrameworkCore.Migrations;

namespace LandingPageTemplate.Server.Migrations
{
    public partial class AddAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO AspNetRoles (Id, [Name], NormalizedName)
                                   VALUES('28eee3ce-c114-486d-85b8-a3e603a898d0', 'Admin', 'Admin')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
