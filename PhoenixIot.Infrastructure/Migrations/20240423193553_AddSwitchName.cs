using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoenixIot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSwitchName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "water_switch_2",
                table: "Devices",
                newName: "switch_4");

            migrationBuilder.RenameColumn(
                name: "water_switch_1",
                table: "Devices",
                newName: "switch_3");

            migrationBuilder.RenameColumn(
                name: "fan_switch_2",
                table: "Devices",
                newName: "switch_2");

            migrationBuilder.RenameColumn(
                name: "fan_switch_1",
                table: "Devices",
                newName: "switch_1");

            migrationBuilder.AddColumn<string>(
                name: "switch_1_name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "switch_2_name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "switch_3_name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "switch_4_name",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "switch_1_name",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "switch_2_name",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "switch_3_name",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "switch_4_name",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "switch_4",
                table: "Devices",
                newName: "water_switch_2");

            migrationBuilder.RenameColumn(
                name: "switch_3",
                table: "Devices",
                newName: "water_switch_1");

            migrationBuilder.RenameColumn(
                name: "switch_2",
                table: "Devices",
                newName: "fan_switch_2");

            migrationBuilder.RenameColumn(
                name: "switch_1",
                table: "Devices",
                newName: "fan_switch_1");
        }
    }
}
