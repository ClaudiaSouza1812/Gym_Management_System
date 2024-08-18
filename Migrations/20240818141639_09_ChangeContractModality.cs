using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _09_ChangeContractModality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractModality_Modality_ModalityId",
                table: "ContractModality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractModality",
                table: "ContractModality");

            migrationBuilder.DropColumn(
                name: "ModalityPackage",
                table: "ContractModality");

            migrationBuilder.AlterColumn<int>(
                name: "ModalityId",
                table: "ContractModality",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractModality",
                table: "ContractModality",
                columns: new[] { "ContractId", "ModalityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContractModality_Modality_ModalityId",
                table: "ContractModality",
                column: "ModalityId",
                principalTable: "Modality",
                principalColumn: "ModalityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractModality_Modality_ModalityId",
                table: "ContractModality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractModality",
                table: "ContractModality");

            migrationBuilder.AlterColumn<int>(
                name: "ModalityId",
                table: "ContractModality",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ModalityPackage",
                table: "ContractModality",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractModality",
                table: "ContractModality",
                columns: new[] { "ContractId", "ModalityPackage" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContractModality_Modality_ModalityId",
                table: "ContractModality",
                column: "ModalityId",
                principalTable: "Modality",
                principalColumn: "ModalityId");
        }
    }
}
