using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestowySklep.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "Users",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Users",
                newName: "age");
        }
    }
}
