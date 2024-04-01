using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RedesignDeviceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceVariables");

            migrationBuilder.DropColumn(
                name: "wifi_password",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "wifi_username",
                table: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "humidity",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "temperature",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_1",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_10",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_11",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_12",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_13",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_14",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_15",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_16",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_17",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_18",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_19",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_2",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_20",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_3",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_4",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_5",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_6",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_7",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_8",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "val_9",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "humidity",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "temperature",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_1",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_10",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_11",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_12",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_13",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_14",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_15",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_16",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_17",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_18",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_19",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_2",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_20",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_3",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_4",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_5",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_6",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_7",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_8",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "val_9",
                table: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "wifi_password",
                table: "Devices",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "wifi_username",
                table: "Devices",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DeviceVariables",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    device_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    val_1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
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
                    val_2 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_20 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_3 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_4 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_5 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_6 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_7 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_8 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    val_9 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
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
    }
}
