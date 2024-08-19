using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _10_AddDefaultMembershipAndModalities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "MembershipId", "DiscountPercentage", "MembershipType" },
                values: new object[,]
                {
                    { 1, 0m, "Monthly" },
                    { 2, 10m, "Monthly Loyal" },
                    { 3, 0m, "Per Session" }
                });

            migrationBuilder.InsertData(
                table: "Modality",
                columns: new[] { "ModalityId", "ModalityName", "ModalityPackage" },
                values: new object[,]
                {
                    { 1, "Bodybuilding", 3 },
                    { 2, "Swimming", 2 },
                    { 3, "AllModalities", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "ModalityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "ModalityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modality",
                keyColumn: "ModalityId",
                keyValue: 3);
        }
    }
}
