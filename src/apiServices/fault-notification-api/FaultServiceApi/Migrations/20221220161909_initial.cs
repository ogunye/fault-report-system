using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaultServiceApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlazaId = table.Column<int>(type: "int", nullable: false),
                    LaneNumber = table.Column<int>(type: "int", nullable: false),
                    LaneDirection = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FaultDescription = table.Column<string>(name: "Fault_Description", type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LaneStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeReported = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmFaultStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DateTimeConfirmStatus = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faults");
        }
    }
}
