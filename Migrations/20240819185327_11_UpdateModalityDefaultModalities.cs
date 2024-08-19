using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _11_UpdateModalityDefaultModalities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Modality",
                keyColumn: "ModalityId",
                keyValue: 2,
                column: "ModalityName",
                value: "Swimming/Bodybuilding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Modality",
                keyColumn: "ModalityId",
                keyValue: 2,
                column: "ModalityName",
                value: "Swimming");
        }
    }
}
