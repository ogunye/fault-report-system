using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaultServiceApi.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fault",
                columns: table => new
                {
                    FaultSerialNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlazaId = table.Column<int>(type: "int", nullable: false),
                    LaneNumber = table.Column<int>(type: "int", nullable: false),
                    LaneDirection = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FaultDescription = table.Column<string>(name: "Fault_Description", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LaneStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeReported = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmFaultStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateTimeConfirmStatus = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fault", x => x.FaultSerialNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fault");
        }
    }
}
