using Microsoft.EntityFrameworkCore.Migrations;

namespace LLPApp.Data.Migrations
{
    public partial class ModelCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthorizedLoaner",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "LName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Students",
                newName: "FName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Students",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DeviceNumRTC",
                table: "Devices",
                newName: "RTCNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LName",
                table: "Students",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FName",
                table: "Students",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "RTCNum",
                table: "Devices",
                newName: "DeviceNumRTC");

            migrationBuilder.AddColumn<bool>(
                name: "IsAuthorizedLoaner",
                table: "Students",
                nullable: false,
                defaultValue: false);
        }
    }
}
