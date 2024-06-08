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

        builder.Property(x => x.Switch1)
            .HasColumnName("switch_1");

        builder.Property(x => x.Switch2)
            .HasColumnName("switch_2");

        builder.Property(x => x.Switch3)
            .HasColumnName("switch_3");

        builder.Property(x => x.Switch4)
            .HasColumnName("switch_4");

        builder.Property(x => x.Switch1Name)
            .HasColumnName("switch_1_name");

        builder.Property(x => x.Switch2Name)
            .HasColumnName("switch_2_name");

        builder.Property(x => x.Switch3Name)
            .HasColumnName("switch_3_name");

        builder.Property(x => x.Switch4Name)
            .HasColumnName("switch_4_name");

        builder.Property(x => x.Setting)
            .HasColumnName("setting");

        builder.Property(x => x.LastSync)
            .HasColumnName("last_sync");

        builder.Property(x => x.FanSwitchOnAt)
            .HasColumnName("fan_switch_on_at")
            .IsRequired();

        builder.Property(x => x.FanSwitchOffAt)
            .HasColumnName("fan_switch_off_at")
            .IsRequired();

        builder.Property(x => x.WaterSwitchOffAt)
            .HasColumnName("water_switch_off_from")
            .IsRequired();

        // relay 1
        builder.Property(x => x.StartWorkAtRelay1)
            .HasColumnName("relay_1_start_work_at");

        builder.Property(x => x.EndWorkAtRelay1)
            .HasColumnName("relay_1_end_work_at");
        
        // relay 2
        builder.Property(x => x.StartWorkAtRelay2)
            .HasColumnName("relay_2_start_work_at");

        builder.Property(x => x.EndWorkAtRelay2)
            .HasColumnName("relay_2_end_work_at");
        
        // relay 3
        builder.Property(x => x.StartWorkAtRelay3)
            .HasColumnName("relay_3_start_work_at");

        builder.Property(x => x.EndWorkAtRelay3)
            .HasColumnName("relay_3_end_work_at");
        
        // relay 4
        builder.Property(x => x.StartWorkAtRelay4)
            .HasColumnName("relay_4_start_work_at");

        builder.Property(x => x.EndWorkAtRelay4)
            .HasColumnName("relay_4_end_work_at");

        builder.HasOne(x => x.User)
            .WithMany(x => x.Devices);

        builder.Property(x => x.WhetherTemperature)
            .HasColumnName("whether_temperature")
            .HasMaxLength(64);

        builder.Property(x => x.WhetherHumidity)
            .HasColumnName("whether_humidity")
            .HasMaxLength(64);
        
        builder.Property(x => x.SoilHumidity)
            .HasColumnName("soil_humidity")
            .HasMaxLength(64);
        
        builder.Property(x => x.LightBrightness)
            .HasColumnName("light_brightness")
            .HasMaxLength(64);

        builder.Property(x => x.Val1)
            .HasColumnName("val_1")
            .HasMaxLength(256);

        builder.Property(x => x.Val2)
            .HasColumnName("val_2")
            .HasMaxLength(256);

        builder.Property(x => x.Val3)
            .HasColumnName("val_3")
            .HasMaxLength(256);

        builder.Property(x => x.Val4)
            .HasColumnName("val_4")
            .HasMaxLength(256);

        builder.Property(x => x.Val5)
            .HasColumnName("val_5")
            .HasMaxLength(256);

        builder.Property(x => x.Val6)
            .HasColumnName("val_6")
            .HasMaxLength(256);

        builder.Property(x => x.Val7)
            .HasColumnName("val_7")
            .HasMaxLength(256);

        builder.Property(x => x.Val8)
            .HasColumnName("val_8")
            .HasMaxLength(256);

        builder.Property(x => x.Val9)
            .HasColumnName("val_9")
            .HasMaxLength(256);

        builder.Property(x => x.Val10)
            .HasColumnName("val_10")
            .HasMaxLength(256);

        builder.Property(x => x.Val11)
            .HasColumnName("val_11")
            .HasMaxLength(256);

        builder.Property(x => x.Val12)
            .HasColumnName("val_12")
            .HasMaxLength(256);

        builder.Property(x => x.Val13)
            .HasColumnName("val_13")
            .HasMaxLength(256);

        builder.Property(x => x.Val14)
            .HasColumnName("val_14")
            .HasMaxLength(256);

        builder.Property(x => x.Val15)
            .HasColumnName("val_15")
            .HasMaxLength(256);

        builder.Property(x => x.Val16)
            .HasColumnName("val_16")
            .HasMaxLength(256);

        builder.Property(x => x.Val17)
            .HasColumnName("val_17")
            .HasMaxLength(256);

        builder.Property(x => x.Val18)
            .HasColumnName("val_18")
            .HasMaxLength(256);

        builder.Property(x => x.Val19)
            .HasColumnName("val_19")
            .HasMaxLength(256);

        builder.Property(x => x.Val20)
            .HasColumnName("val_20")
            .HasMaxLength(256);
    }
}