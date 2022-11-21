namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services.VideoAnalyzer;

internal interface IVideoAnalyzerService
{
    Task<double> GetVideoDuration(string directory);
}