using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _04_EnumsChangeDataType : Migration
    {
        protected overrIde voId Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaymentType",
                table: "Payment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");

            migrationBuilder.AlterColumn<int>(
                name: "ModalityPackage",
                table: "Modality",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");

            migrationBuilder.AlterColumn<int>(
                name: "ModalityName",
                table: "Modality",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Client",
                type: "int",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }

        protected overrIde voId Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentType",
                table: "Payment",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModalityPackage",
                table: "Modality",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModalityName",
                table: "Modality",
                type: "nvarchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Client",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30);
        }
    }
}
