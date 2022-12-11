namespace AdvertisingBillboards.Models.Models;

public class AdvertisementStatistics
{
    public long Id { get; set; }
    
    public long AdvertisementId { get; set; }
    
    public int TotalViews { get; set; }
}