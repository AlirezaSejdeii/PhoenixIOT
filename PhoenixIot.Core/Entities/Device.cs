namespace PhoenixIot.Core.Entities;

public class Device : BaseEntity
{
    public Device(string identifier, DateTime now)
    {
        Identifier = identifier;
        CreatedAt = now;
    }

    protected Device()
    {
    }

    public string Identifier { get; private set; }
    public bool FanSwitch1 { get; private set; }
    public bool FanSwitch2 { get; private set; }
    public bool WaterSwitch1 { get; private set; }
    public bool WaterSwitch2 { get; private set; }

    public bool ManualSetting { get; private set; }

    // Even manual setting false, relay on this humidity 
    public uint? FanSwitchOnAt { get; private set; } = 50;

    // Even manual setting false, relay on thus temperature
    public uint? WaterSwitchOnAt { get; private set; } = 30;

    public User? User { get; private set; }

    public string? Temperature { get; private set; }
    public string? Humidity { get; private set; }
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
        Temperature = temperature;
        Humidity = humidity;
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
        FanSwitch1 = updateFan1;
        FanSwitch2 = updateFan2;
        WaterSwitch1 = updateWater1;
        WaterSwitch2 = updateWater2;
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
}