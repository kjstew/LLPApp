using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LLPApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RTCNum = table.Column<int>(nullable: false),
                    DeviceNum = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Make = table.Column<string>(maxLength: 40, nullable: false),
                    Model = table.Column<string>(maxLength: 40, nullable: false),
                    ModelNum = table.Column<string>(maxLength: 40, nullable: false),
                    SerialNum = table.Column<string>(maxLength: 100, nullable: false),
                    OperatingSystem = table.Column<string>(maxLength: 40, nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateRetired = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
