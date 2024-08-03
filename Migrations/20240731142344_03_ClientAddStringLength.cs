using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _03_ClientAddStringLength : Migration
    {
        protected overrIde voId Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Client",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");
        }

        protected overrIde voId Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Client",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
