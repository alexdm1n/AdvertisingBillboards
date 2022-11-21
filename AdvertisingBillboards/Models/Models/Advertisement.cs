namespace AdvertisingBillboards.Models.Models;

public class Advertisement
{
    public long Id { get; set; }

    public bool IsDeleted { get; set; }
    
    public double Duration { get; set; }
    
    public double MemoryLength { get; set; }

    public string FileName { get; set; }

    public string Path { get; set; }

    public Device Device { get; set; }

    public bool IsActive { get; set; }
}