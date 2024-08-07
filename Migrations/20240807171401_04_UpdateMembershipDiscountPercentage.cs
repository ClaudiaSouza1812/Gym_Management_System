using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Migrations
{
    public partial class _04_UpdateMembershipDiscountPercentage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Membership",
                newName: "DiscountPercentage");

            migrationBuilder.AlterColumn<string>(
                name: "MembershipType",
                table: "Membership",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountPercentage",
                table: "Membership",
                newName: "Discount");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipType",
                table: "Membership",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
