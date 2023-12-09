using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcf.Lab.DynamicContext.Api.Migrations
{
    /// <inheritdoc />
    public partial class ClientConnectionStringAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientSetting",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionString",
                table: "Clients",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionString",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "ClientSetting",
                table: "Clients",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
