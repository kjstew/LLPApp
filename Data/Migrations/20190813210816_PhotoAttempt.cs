using Microsoft.EntityFrameworkCore.Migrations;

namespace LLPApp.Migrations
{
    public partial class PhotoAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "DeviceModels",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "DeviceModels",
                newName: "ImgUrl");
        }
    }
}
