namespace AdvertisingBillboards.Models.Models;

public class Advertisement
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; }
    
    public long AdvLength { get; set; }
    
    public long MaxAdvLength { get; set; }

    public string FileName { get; set; }

    public string Path { get; set; }

    public Device Device { get; set; }

    public bool IsActive { get; set; }
}