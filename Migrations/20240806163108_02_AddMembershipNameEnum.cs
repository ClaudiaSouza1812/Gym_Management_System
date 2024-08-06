using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _02_AddMembershipNameEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipName",
                table: "Membership",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreateClientViewModel",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentBaseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentBaseRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CreateClientViewModel_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreateClientViewModel_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreateClientViewModel_Modality_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "Modality",
                        principalColumn: "ModalityId",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateClientViewModel");

            migrationBuilder.DropColumn(
                name: "MembershipName",
                table: "Membership");
        }
    }
}
