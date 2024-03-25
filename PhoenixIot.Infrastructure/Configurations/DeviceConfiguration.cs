using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Configurations;

public class DeviceConfiguration:BaseConfiguration<Device>
{
    protected override void ExtraConfigure(EntityTypeBuilder<Device> builder)
    {
        builder.Property(x => x.Identifier)
            .HasColumnName("identifier")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.WifiUsername)
            .HasColumnName("wifi_username")
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.WifiPassword)
            .HasColumnName("wifi_password")
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.FanSwitch1)
            .HasColumnName("fan_switch_1");
        builder.Property(x => x.FanSwitch2)
            .HasColumnName("fan_switch_2");
        builder.Property(x => x.WaterSwitch1)
            .HasColumnName("water_switch_1");
        builder.Property(x => x.WaterSwitch2)
            .HasColumnName("water_switch_2");
        builder.Property(x => x.ManualSetting)
            .HasColumnName("manual_setting");
        builder.Property(x => x.FanSwitchOnAt)
            .HasColumnName("fan_switch_on_temp")
            .IsRequired(false);
        builder.Property(x => x.FanSwitchOnAt)
            .HasColumnName("water_switch_on_humidity")
            .IsRequired(false);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Devices);

    }
}
