namespace PhoenixIot.Core.Entities;

public class DeviceVariables : BaseEntity
{
    public DeviceVariables(DateTime now, Device device)
    {
        CreatedAt = now;
        Device = device;
    }

    protected DeviceVariables()
    {
        
    }
    
    public Device Device { get; set; }
}