using System.Security.AccessControl;
using PhoenixIot.Core.Enums;

namespace PhoenixIot.Core.Entities;

public class Device : BaseEntity
{
    public Device(
        string identifier,
        string switch1Name,
        string switch2Name,
        string switch3Name,
        string switch4Name,
        DateTime now)
    {
        Identifier = identifier;
        Switch1Name = switch1Name;
        Switch2Name = switch2Name;
        Switch3Name = switch3Name;
        Switch4Name = switch4Name;
        CreatedAt = now;
    }

    protected Device()
    {
    }

    public string Identifier { get; private set; }
    public bool Switch1 { get; private set; }
    public bool Switch2 { get; private set; }
    public bool Switch3 { get; private set; }
    public bool Switch4 { get; private set; }
    public string Switch1Name { get; private set; }
    public string Switch2Name { get; private set; }
    public string Switch3Name { get; private set; }
    public string Switch4Name { get; private set; }

    public SettingMode Setting { get; private set; }

    // ---------------------------------------------------------------------------------
    // These setting just work when the Setting set Sensor
    // Fan do their job when Temperature is X and end their job when Temperature is Y
    public int WhetherHumidityLimit { get; private set; }
    public int WhetherTemperatureLimit { get; private set; }
    public int SoilHumidityLimit { get; private set; }
    public int LightBrightnessLimit { get; private set; }

    // ---------------------------------------------------------------------------------
    // These setting just work when the Setting set Timer
    public TimeOnly StartWorkAtRelay1 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(8));
    public TimeOnly EndWorkAtRelay1 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(12));

    public TimeOnly StartWorkAtRelay2 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(8));
    public TimeOnly EndWorkAtRelay2 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(12));

    public TimeOnly StartWorkAtRelay3 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(8));
    public TimeOnly EndWorkAtRelay3 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(12));

    public TimeOnly StartWorkAtRelay4 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(8));
    public TimeOnly EndWorkAtRelay4 { get; private set; } = TimeOnly.FromTimeSpan(TimeSpan.FromHours(12));
    // ---------------------------------------------------------------------------------

    public User? User { get; private set; }
    public DateTime? LastSync { get; private set; }

    public string? WhetherTemperature { get; private set; }
    public string? WhetherHumidity { get; private set; }
    public string? SoilHumidity { get; private set; }
    public string? LightBrightness { get; private set; }
    public string? Val1 { get; private set; }
    public string? Val2 { get; private set; }
    public string? Val3 { get; private set; }
    public string? Val4 { get; private set; }
    public string? Val5 { get; private set; }
    public string? Val6 { get; private set; }
    public string? Val7 { get; private set; }
    public string? Val8 { get; private set; }
    public string? Val9 { get; private set; }
    public string? Val10 { get; private set; }
    public string? Val11 { get; private set; }
    public string? Val12 { get; private set; }
    public string? Val13 { get; private set; }
    public string? Val14 { get; private set; }
    public string? Val15 { get; private set; }
    public string? Val16 { get; private set; }
    public string? Val17 { get; private set; }
    public string? Val18 { get; private set; }
    public string? Val19 { get; private set; }
    public string? Val20 { get; private set; }

    public void UpdateVariables(
        string? whetherTemperature,
        string? whetherHumidity,
        string? soilHumidity,
        string? lightBrightness,
        string? val1,
        string? val2,
        string? val3,
        string? val4,
        string? val5,
        string? val6,
        string? val7,
        string? val8,
        string? val9,
        string? val10,
        string? val11,
        string? val12,
        string? val13,
        string? val14,
        string? val15,
        string? val16,
        string? val17,
        string? val18,
        string? val19,
        string? val20,
        DateTime now)
    {
        WhetherTemperature = whetherTemperature;
        WhetherHumidity = whetherHumidity;
        SoilHumidity = soilHumidity;
        LightBrightness = lightBrightness;
        Val1 = val1;
        Val2 = val2;
        Val3 = val3;
        Val4 = val4;
        Val5 = val5;
        Val6 = val6;
        Val7 = val7;
        Val8 = val8;
        Val9 = val9;
        Val10 = val10;
        Val11 = val11;
        Val12 = val12;
        Val13 = val13;
        Val14 = val14;
        Val15 = val15;
        Val16 = val16;
        Val17 = val17;
        Val18 = val18;
        Val19 = val19;
        Val20 = val20;
        UpdatedAt = now;
    }

    public void SetIdentifier(string newIdentifier, DateTime now)
    {
        Identifier = newIdentifier;
        UpdatedAt = now;
    }

    public void UpdateRelays(bool relay1, bool relay2, bool relay3, bool relay4, DateTime now)
    {
        Setting = SettingMode.Manual;
        Switch1 = relay1;
        Switch2 = relay2;
        Switch3 = relay3;
        Switch4 = relay4;
        UpdatedAt = now;
    }

    public bool IsBelongToUser(Guid userId)
    {
        if (User != null && User.Id == userId)
        {
            return true;
        }

        return false;
    }

    public void UpdateLastSync(DateTime now)
    {
        LastSync = now;
        UpdatedAt = now;
    }

    public void SetupDeviceRelays(DateTime now)
    {
        if (Setting == SettingMode.Sensor)
        {
            Switch1 = decimal.Parse(WhetherHumidity!) >= WhetherHumidityLimit;
            Switch2 = decimal.Parse(WhetherTemperature!) >= WhetherTemperatureLimit;
            Switch3 = decimal.Parse(SoilHumidity!) <= SoilHumidityLimit;
            Switch4 = decimal.Parse(LightBrightness!) <= LightBrightnessLimit;
        }

        if (Setting == SettingMode.Timer)
        {
            Switch1 = ShouldBeOn(now, StartWorkAtRelay1, EndWorkAtRelay1);
            Switch2 = ShouldBeOn(now, StartWorkAtRelay2, EndWorkAtRelay2);
            Switch3 = ShouldBeOn(now, StartWorkAtRelay3, EndWorkAtRelay3);
            Switch4 = ShouldBeOn(now, StartWorkAtRelay4, EndWorkAtRelay4);
        }
    }


    public bool IsSync()
    {
        if (Setting == SettingMode.Manual)
        {
            return LastSync >= UpdatedAt?.AddSeconds(-10);
        }

        if (Setting == SettingMode.Sensor)
        {
            bool relay1ShouldBeOn = decimal.Parse(WhetherHumidity!) >= WhetherHumidityLimit;
            bool relay2ShouldBeOn = decimal.Parse(WhetherTemperature!) >= WhetherTemperatureLimit;
            bool relay3ShouldBeOn = decimal.Parse(SoilHumidity!) <= SoilHumidityLimit;
            bool relay4ShouldBeOn = decimal.Parse(LightBrightness!) <= LightBrightnessLimit;

            if (relay1ShouldBeOn && Switch1 ||
                relay2ShouldBeOn && Switch2 ||
                relay3ShouldBeOn && Switch3 ||
                relay4ShouldBeOn && Switch4)
            {
                return true;
            }

            if (!relay1ShouldBeOn && !Switch1 ||
                !relay2ShouldBeOn && !Switch2 ||
                !relay3ShouldBeOn && !Switch3 ||
                !relay4ShouldBeOn && !Switch4)
            {
                return true;
            }

            return false;
        }

        if (Setting == SettingMode.Timer)
        {
            bool relay1ShouldBeOn = ShouldBeOn(DateTime.Now, StartWorkAtRelay1, EndWorkAtRelay1);
            bool relay2ShouldBeOn = ShouldBeOn(DateTime.Now, StartWorkAtRelay2, EndWorkAtRelay2);
            bool relay3ShouldBeOn = ShouldBeOn(DateTime.Now, StartWorkAtRelay3, EndWorkAtRelay3);
            bool relay4ShouldBeOn = ShouldBeOn(DateTime.Now, StartWorkAtRelay4, EndWorkAtRelay4);

            if (relay1ShouldBeOn && Switch1 ||
                relay2ShouldBeOn && Switch2 ||
                relay3ShouldBeOn && Switch3 ||
                relay4ShouldBeOn && Switch4)
            {
                return true;
            }

            if (!relay1ShouldBeOn && !Switch1 ||
                !relay2ShouldBeOn && !Switch2 ||
                !relay3ShouldBeOn && !Switch3 ||
                !relay4ShouldBeOn && !Switch4)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public void SetTimer(
        TimeOnly updateStartAtRelay1, 
        TimeOnly updateEndAtRelay1, 
        TimeOnly updateStartAtRelay2, 
        TimeOnly updateEndAtRelay2, 
        TimeOnly updateStartAtRelay3, 
        TimeOnly updateEndAtRelay3, 
        TimeOnly updateStartAtRelay4, 
        TimeOnly updateEndAtRelay4, 
        DateTime now)
    {
        Setting = SettingMode.Timer;
        StartWorkAtRelay1 = updateStartAtRelay1;
        EndWorkAtRelay1 = updateEndAtRelay1;
        
        StartWorkAtRelay2 = updateStartAtRelay2;
        EndWorkAtRelay2 = updateEndAtRelay2;
        
        StartWorkAtRelay3 = updateStartAtRelay3;
        EndWorkAtRelay3 = updateEndAtRelay3;
        
        StartWorkAtRelay4 = updateStartAtRelay4;
        EndWorkAtRelay4 = updateEndAtRelay4;
        UpdatedAt = now;
    }

    public void SetSensorValues(
        int whetherHumidityLimit, 
        int whetherTemperatureLimit,
        int soilHumidityLimit,
        int lightBrightnessLimit,
        DateTime now)
    {
        Setting = SettingMode.Sensor;
        WhetherHumidityLimit = whetherHumidityLimit;
        WhetherTemperatureLimit = whetherTemperatureLimit;
        SoilHumidityLimit = soilHumidityLimit;
        LightBrightnessLimit = lightBrightnessLimit;
        UpdatedAt = now;
    }

    public void UpdatedSwitchName(
        string switch1Name,
        string switch2Name,
        string switch3Name,
        string switch4Name,
        DateTime now)
    {
        Switch1Name = switch1Name;
        Switch2Name = switch2Name;
        Switch3Name = switch3Name;
        Switch4Name = switch4Name;
        UpdatedAt = now;
    }

    private static bool ShouldBeOn(DateTime now, TimeOnly startWork, TimeOnly endWork)
    {
        TimeSpan start = startWork.ToTimeSpan();
        TimeSpan end = endWork.ToTimeSpan();
        TimeSpan currentTime = now.TimeOfDay;

        return (end < start && (currentTime >= start || currentTime <= end)) ||
               (currentTime >= start && currentTime <= end);
    }
}