using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRedundantVaribles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceVariables",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    val_1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_3 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_4 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_5 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_6 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_7 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_8 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_9 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_10 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_11 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_12 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_13 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_14 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_15 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_16 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_17 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_18 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_19 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_20 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    device_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceVariables", x => x.id);
                    table.ForeignKey(
                        name: "FK_DeviceVariables_Devices_device_id",
                        column: x => x.device_id,
                        principalTable: "Devices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceVariables_device_id",
                table: "DeviceVariables",
                column: "device_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceVariables");
        }
    }
}
