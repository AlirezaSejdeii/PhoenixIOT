using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOtherSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaterSwitchOnAt",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "water_switch_on_humidity",
                table: "Devices",
                newName: "fan_switch_on_at");

            migrationBuilder.AlterColumn<int>(
                name: "fan_switch_on_at",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "end_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "fan_switch_off_at",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "start_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "water_switch_off_from",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "fan_switch_off_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "start_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "water_switch_off_from",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "fan_switch_on_at",
                table: "Devices",
                newName: "water_switch_on_humidity");

            migrationBuilder.AlterColumn<long>(
                name: "water_switch_on_humidity",
                table: "Devices",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "WaterSwitchOnAt",
                table: "Devices",
                type: "bigint",
                nullable: true);
        }
    }
}
