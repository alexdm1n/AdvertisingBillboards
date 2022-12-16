namespace AdvertisingBillboards.Models.Models;

public class Device
{
    public long Id { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public int Frequency { get; set; }
    
    public long UserId { get; set; }
    
    public DeviceGroup DeviceGroup { get; set; }
    
    public User User { get; set; }
    
    public IEnumerable<Advertisement> Advertisements { get; set; }
    
    public bool Status { get; set; }
}