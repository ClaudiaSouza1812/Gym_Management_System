using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _03_AddContractEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreateClientViewModel_Client_ClientId",
                table: "CreateClientViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CreateClientViewModel_Membership_MembershipId",
                table: "CreateClientViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CreateClientViewModel_Modality_ModalityId",
                table: "CreateClientViewModel");

            migrationBuilder.DropIndex(
                name: "IX_CreateClientViewModel_ClientId",
                table: "CreateClientViewModel");

            migrationBuilder.DropIndex(
                name: "IX_CreateClientViewModel_MembershipId",
                table: "CreateClientViewModel");

            migrationBuilder.DropIndex(
                name: "IX_CreateClientViewModel_ModalityId",
                table: "CreateClientViewModel");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "CreateClientViewModel");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "CreateClientViewModel");

            migrationBuilder.DropColumn(
                name: "ModalityId",
                table: "CreateClientViewModel");

            migrationBuilder.RenameColumn(
                name: "MembershipName",
                table: "Membership",
                newName: "MembershipType");

            migrationBuilder.RenameColumn(
                name: "ContractDate",
                table: "Contract",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Contract",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaymentType",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "MembershipType",
                table: "Membership",
                newName: "MembershipName");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Contract",
                newName: "ContractDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Membership",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "CreateClientViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "CreateClientViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModalityId",
                table: "CreateClientViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1,
                column: "PaymentType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2,
                column: "PaymentType",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_CreateClientViewModel_ClientId",
                table: "CreateClientViewModel",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreateClientViewModel_MembershipId",
                table: "CreateClientViewModel",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_CreateClientViewModel_ModalityId",
                table: "CreateClientViewModel",
                column: "ModalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreateClientViewModel_Client_ClientId",
                table: "CreateClientViewModel",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreateClientViewModel_Membership_MembershipId",
                table: "CreateClientViewModel",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "MembershipId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreateClientViewModel_Modality_ModalityId",
                table: "CreateClientViewModel",
                column: "ModalityId",
                principalTable: "Modality",
                principalColumn: "ModalityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
