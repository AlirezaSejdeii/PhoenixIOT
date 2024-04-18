using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoenixIot.Core.Entities;

namespace PhoenixIot.Infrastructure.Configurations;

public class DeviceConfiguration : BaseConfiguration<Device>
{
    protected override void ExtraConfigure(EntityTypeBuilder<Device> builder)
    {
        builder.Property(x => x.Identifier)
            .HasColumnName("identifier")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(x => x.FanSwitch1)
            .HasColumnName("fan_switch_1");
        
        builder.Property(x => x.FanSwitch2)
            .HasColumnName("fan_switch_2");
        
        builder.Property(x => x.WaterSwitch1)
            .HasColumnName("water_switch_1");
        
        builder.Property(x => x.WaterSwitch2)
            .HasColumnName("water_switch_2");

        builder.Property(x => x.Setting)
            .HasColumnName("setting");
        
        builder.Property(x => x.LastSync)
            .HasColumnName("last_sync");
        
        builder.Property(x => x.FanSwitchOnAt)
            .HasColumnName("fan_switch_on_temp")
            .IsRequired(false);
        
        builder.Property(x => x.FanSwitchOnAt)
            .HasColumnName("water_switch_on_humidity")
            .IsRequired(false);
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.Devices);
        
        builder.Property(x => x.Temperature)
            .HasColumnName("temperature")
            .HasMaxLength(64);
        
        builder.Property(x => x.Humidity)
            .HasColumnName("humidity")
            .HasMaxLength(64);
       
        builder.Property(x => x.Val1)
            .HasColumnName("val_1")
            .HasMaxLength(64);

        builder.Property(x => x.Val2)
            .HasColumnName("val_2")
            .HasMaxLength(64);

        builder.Property(x => x.Val3)
            .HasColumnName("val_3")
            .HasMaxLength(64);

        builder.Property(x => x.Val4)
            .HasColumnName("val_4")
            .HasMaxLength(64);

        builder.Property(x => x.Val5)
            .HasColumnName("val_5")
            .HasMaxLength(64);

        builder.Property(x => x.Val6)
            .HasColumnName("val_6")
            .HasMaxLength(64);

        builder.Property(x => x.Val7)
            .HasColumnName("val_7")
            .HasMaxLength(64);

        builder.Property(x => x.Val8)
            .HasColumnName("val_8")
            .HasMaxLength(64);

        builder.Property(x => x.Val9)
            .HasColumnName("val_9")
            .HasMaxLength(64);

        builder.Property(x => x.Val10)
            .HasColumnName("val_10")
            .HasMaxLength(64);

        builder.Property(x => x.Val11)
            .HasColumnName("val_11")
            .HasMaxLength(64);

        builder.Property(x => x.Val12)
            .HasColumnName("val_12")
            .HasMaxLength(64);

        builder.Property(x => x.Val13)
            .HasColumnName("val_13")
            .HasMaxLength(64);

        builder.Property(x => x.Val14)
            .HasColumnName("val_14")
            .HasMaxLength(64);

        builder.Property(x => x.Val15)
            .HasColumnName("val_15")
            .HasMaxLength(64);

        builder.Property(x => x.Val16)
            .HasColumnName("val_16")
            .HasMaxLength(64);

        builder.Property(x => x.Val17)
            .HasColumnName("val_17")
            .HasMaxLength(64);

        builder.Property(x => x.Val18)
            .HasColumnName("val_18")
            .HasMaxLength(64);

        builder.Property(x => x.Val19)
            .HasColumnName("val_19")
            .HasMaxLength(64);

        builder.Property(x => x.Val20)
            .HasColumnName("val_20")
            .HasMaxLength(64);
    }
}