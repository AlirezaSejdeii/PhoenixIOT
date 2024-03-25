namespace PhoenixIot.Core.Entities;

public class Device(string identifier,
        string wifiUsername,
        string wifiPassword,
        bool fanSwitch1,
        bool fanSwitch2,
        bool waterSwitch1,
        bool waterSwitch2)
    : BaseEntity
{
    public string Identifier { get; set; } = identifier;
    public string WifiUsername { get; set; } = wifiUsername;
    public string WifiPassword { get; set; } = wifiPassword;
    public bool FanSwitch1 { get; set; } = fanSwitch1;
    public bool FanSwitch2 { get; set; } = fanSwitch2;
    public bool WaterSwitch1 { get; set; } = waterSwitch1;
    public bool WaterSwitch2 { get; set; } = waterSwitch2;

    public bool ManualSetting { get; set; }
    // Even manual setting false, relay on this humidity 
    public uint? FanSwitchOnAt { get; set; } = 50;
    // Even manual setting false, relay on thus temperature
    public uint? WaterSwitchOnAt { get; set; } = 30;
    
    public User? User { get; set; }
}