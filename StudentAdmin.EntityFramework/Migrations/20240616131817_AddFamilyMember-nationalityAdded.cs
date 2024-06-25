using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAdmin.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddFamilyMembernationalityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "FamilyMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "FamilyMembers");
        }
    }
}
