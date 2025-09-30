using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Energy_Usage_Monitor.Persistence.Data.Migrations
{
    public partial class EnergyUsageModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricalDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerRatingWatts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsOn = table.Column<bool>(type: "bit", nullable: false),
                    LastTurnOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    ModifiedBy = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    EnergyConsumedKWh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElectricalDeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceUsages_ElectricalDevices_ElectricalDeviceId",
                        column: x => x.ElectricalDeviceId,
                        principalTable: "ElectricalDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceUsages_ElectricalDeviceId",
                table: "DeviceUsages",
                column: "ElectricalDeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "DeviceUsages");
            migrationBuilder.DropTable(name: "ElectricalDevices");
        }
    }
}
