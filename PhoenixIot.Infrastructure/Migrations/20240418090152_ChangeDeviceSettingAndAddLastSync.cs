using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeviceSettingAndAddLastSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "manual_setting",
                table: "Devices");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_sync",
                table: "Devices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "setting",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_sync",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "setting",
                table: "Devices");

            migrationBuilder.AddColumn<bool>(
                name: "manual_setting",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
