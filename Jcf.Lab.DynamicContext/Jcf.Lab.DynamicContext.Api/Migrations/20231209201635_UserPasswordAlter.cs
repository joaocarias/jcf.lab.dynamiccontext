using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.Lab.DynamicContext.Api.Migrations
{
    /// <inheritdoc />
    public partial class UserPasswordAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Users",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Senha");
        }
    }
}
