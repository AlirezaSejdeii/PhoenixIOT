using PhoenixIot.Core.Entities;

namespace PhoenixIot.Entities;

public class Device : BaseEntity
{
    public string Identifier { get; set; } = null!;
    public string WifiUsername { get; set; } = null!;
    public string WifiPassword { get; set; } = null!;
    public User User { get; set; } = null!;
    public bool FanSwitch1 { get; set; }
    public bool FanSwitch2 { get; set; }
    public bool WaterSwitch1 { get; set; }
    public bool WaterSwitch2 { get; set; }

    public bool ManualSetting { get; set; }
    // Even manual setting false, relay on this humidity 
    public uint FanSwitchOnAt { get; set; } = 50;
    // Even manual setting false, relay on thus temperature
    public uint WaterSwitchOnAt { get; set; } = 30;
}