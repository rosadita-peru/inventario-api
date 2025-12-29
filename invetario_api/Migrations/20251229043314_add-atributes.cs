using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace invetario_api.Migrations
{
    /// <inheritdoc />
    public partial class addatributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "unitName",
                table: "Units",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Categories",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Units",
                newName: "unitName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "categoryName");
        }
    }
}
