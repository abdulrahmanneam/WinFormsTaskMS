using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinFormsTaskMS.Migrations
{
    /// <inheritdoc />
    public partial class Updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Passowrd",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passowrd",
                table: "user");
        }
    }
}
