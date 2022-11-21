namespace AdvertisingBillboards.Src.AdvertisingBillboards.Services.VideoAnalyzer;

internal class VideoAnalyzerService : IVideoAnalyzerService
{
    public async Task<double> GetVideoDuration(string directory)
    {
        var filePath = Path.Combine(directory, "file.mp4");
        var analyzer = new Alturos.VideoInfo.VideoAnalyzer(Path.Combine(directory, "ffmpeg", "ffprobe.exe"));
        var result = await analyzer.GetVideoInfoAsync(filePath);
        return result.VideoInfo.Format.Duration;
    }
}