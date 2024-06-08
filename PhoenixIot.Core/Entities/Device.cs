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
    public int FanSwitchOnAt { get; private set; } = 25;
    public int FanSwitchOffAt { get; private set; } = 30;

    // Water switch should be OFF when Humidity is equal and greater than X
    public int WaterSwitchOffAt { get; private set; } = 50;

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
        string? temperature,
        string? humidity,
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
        WhetherTemperature = temperature;
        WhetherHumidity = humidity;
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

    public void UpdateRelays(bool updateFan1, bool updateFan2, bool updateWater1, bool updateWater2, DateTime now)
    {
        Setting = SettingMode.Manual;
        Switch1 = updateFan1;
        Switch2 = updateFan2;
        Switch3 = updateWater1;
        Switch4 = updateWater2;
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
            if (decimal.Parse(WhetherTemperature!) >= FanSwitchOnAt && decimal.Parse(WhetherTemperature!) <= FanSwitchOffAt)
            {
                Switch1 = true;
                Switch2 = true;
            }
            else
            {
                Switch1 = false;
                Switch2 = false;
            }

            if (decimal.Parse(WhetherHumidity!) <= WaterSwitchOffAt)
            {
                Switch3 = true;
                Switch4 = true;
            }
            else
            {
                Switch3 = false;
                Switch4 = false;
            }
        }

        if (Setting == SettingMode.Timer)
        {
            TimeSpan start = StartWorkAtRelay1.ToTimeSpan();
            TimeSpan end = EndWorkAtRelay1.ToTimeSpan();
            TimeSpan currentTime = now.TimeOfDay;

            if (
                (end < start && (currentTime >= start || currentTime <= end)) ||
                (currentTime >= start && currentTime <= end))
            {
                Switch1 = true;
                Switch2 = true;
                Switch3 = true;
                Switch4 = true;
            }
            else
            {
                Switch1 = false;
                Switch2 = false;
                Switch3 = false;
                Switch4 = false;
            }
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
            bool isFanOn = Switch1 && Switch2;
            bool isWaterOn = Switch3 & Switch4;

            bool fanShouldBeOn = decimal.Parse(WhetherTemperature!) >= FanSwitchOnAt &&
                                 decimal.Parse(WhetherTemperature!) <= FanSwitchOffAt;

            bool waterShouldBeOn = decimal.Parse(WhetherHumidity!) <= WaterSwitchOffAt;
            if (fanShouldBeOn && isFanOn || !fanShouldBeOn && !isFanOn)
            {
                return true;
            }

            if (waterShouldBeOn&isWaterOn||!waterShouldBeOn&!isWaterOn)
            {
                return true;
            }

            return false;
        }

        if (Setting == SettingMode.Timer)
        {
            TimeSpan start = StartWorkAtRelay1.ToTimeSpan();
            TimeSpan end = EndWorkAtRelay1.ToTimeSpan();
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            bool isCurrentTimeBetweenStartAndEnd = end < start
                ? (currentTime >= start || currentTime <= end)
                : (currentTime >= start && currentTime <= end);

            bool allSwitchesTrue = Switch1 && Switch2 && Switch3 && Switch4;

            if (isCurrentTimeBetweenStartAndEnd && allSwitchesTrue)
            {
                return true;
            }

            if (!isCurrentTimeBetweenStartAndEnd && !Switch1 && !Switch2 && !Switch3 && !Switch4)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public void SetTimer(TimeOnly updateStartAt, TimeOnly updateEndAt, DateTime now)
    {
        Setting = SettingMode.Timer;
        StartWorkAtRelay1 = updateStartAt;
        EndWorkAtRelay1 = updateEndAt;
        UpdatedAt = now;
    }

    public void SetSensorValues(int updateFanOnAtTemp, int updateFanOffAtTemp, int updateWaterOffFromHumidity,
        DateTime now)
    {
        Setting = SettingMode.Sensor;
        FanSwitchOnAt = updateFanOnAtTemp;
        FanSwitchOffAt = updateFanOffAtTemp;
        WaterSwitchOffAt = updateWaterOffFromHumidity;
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
}