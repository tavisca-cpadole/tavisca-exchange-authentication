using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AuthenticationPortal.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureWebHostDefaults(webHostBuilder =>
        {
            webHostBuilder
              .UseStartup<Startup>();
        })
        .ConfigureAppConfiguration((context, config) =>
        {
            config.AddSystemsManager("/cognito");
        })
        .Build();

            host.Run();
        }
    }
}
