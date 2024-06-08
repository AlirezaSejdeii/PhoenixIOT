using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewVariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temperature",
                table: "Devices",
                newName: "whether_temperature");

            migrationBuilder.RenameColumn(
                name: "start_work_at",
                table: "Devices",
                newName: "relay_4_start_work_at");

            migrationBuilder.RenameColumn(
                name: "humidity",
                table: "Devices",
                newName: "whether_humidity");

            migrationBuilder.RenameColumn(
                name: "end_work_at",
                table: "Devices",
                newName: "relay_4_end_work_at");

            migrationBuilder.AddColumn<string>(
                name: "light_brightness",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "relay_1_end_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "relay_1_start_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "relay_2_end_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "relay_2_start_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "relay_3_end_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "relay_3_start_work_at",
                table: "Devices",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "soil_humidity",
                table: "Devices",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "light_brightness",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "relay_1_end_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "relay_1_start_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "relay_2_end_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "relay_2_start_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "relay_3_end_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "relay_3_start_work_at",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "soil_humidity",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "whether_temperature",
                table: "Devices",
                newName: "temperature");

            migrationBuilder.RenameColumn(
                name: "whether_humidity",
                table: "Devices",
                newName: "humidity");

            migrationBuilder.RenameColumn(
                name: "relay_4_start_work_at",
                table: "Devices",
                newName: "start_work_at");

            migrationBuilder.RenameColumn(
                name: "relay_4_end_work_at",
                table: "Devices",
                newName: "end_work_at");
        }
    }
}
