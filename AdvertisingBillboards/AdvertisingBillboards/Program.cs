using NLog.Web;
using Microsoft.AspNetCore;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace AdvertisingBillboards;

public class Program
{
    public static NLog.Logger Logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)  
            .UseStartup<Startup>()  
            .ConfigureLogging(logging =>  
            {  
                logging.ClearProviders();  
                logging.SetMinimumLevel(LogLevel.Information);  
            })  
            .UseNLog();
}