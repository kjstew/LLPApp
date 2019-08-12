using Microsoft.EntityFrameworkCore.Migrations;

namespace LLPApp.Migrations
{
    public partial class RenameDeviceModelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceModel_DeviceModelId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceModel",
                table: "DeviceModel");

            migrationBuilder.RenameTable(
                name: "DeviceModel",
                newName: "DeviceModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceModels",
                table: "DeviceModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceModels_DeviceModelId",
                table: "Devices",
                column: "DeviceModelId",
                principalTable: "DeviceModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceModels_DeviceModelId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeviceModels",
                table: "DeviceModels");

            migrationBuilder.RenameTable(
                name: "DeviceModels",
                newName: "DeviceModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeviceModel",
                table: "DeviceModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceModel_DeviceModelId",
                table: "Devices",
                column: "DeviceModelId",
                principalTable: "DeviceModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
