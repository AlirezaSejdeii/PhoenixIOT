using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSensorLimitValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "water_switch_off_from",
                table: "Devices",
                newName: "whether_temperature_limit");

            migrationBuilder.RenameColumn(
                name: "fan_switch_on_at",
                table: "Devices",
                newName: "whether_humidity_limit");

            migrationBuilder.RenameColumn(
                name: "fan_switch_off_at",
                table: "Devices",
                newName: "soil_humidity_limit");

            migrationBuilder.AddColumn<int>(
                name: "light_brightness_limit",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "light_brightness_limit",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "whether_temperature_limit",
                table: "Devices",
                newName: "water_switch_off_from");

            migrationBuilder.RenameColumn(
                name: "whether_humidity_limit",
                table: "Devices",
                newName: "fan_switch_on_at");

            migrationBuilder.RenameColumn(
                name: "soil_humidity_limit",
                table: "Devices",
                newName: "fan_switch_off_at");
        }
    }
}
