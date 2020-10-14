using Microsoft.EntityFrameworkCore.Migrations;

namespace LandingPageTemplate.Server.Migrations
{
    public partial class UpdateSocialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SocialLinks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialImage",
                table: "SocialLinks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "SocialImage",
                table: "SocialLinks");
        }
    }
}
