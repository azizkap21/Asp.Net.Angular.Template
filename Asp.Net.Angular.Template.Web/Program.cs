using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Asp.Net.Angular.Template.Web
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
             .ConfigureLogging(logging =>
             {
               logging.ClearProviders();
               logging.AddConsole();
               logging.AddApplicationInsights();
             })
            .UseStartup<Startup>();
  }
}
