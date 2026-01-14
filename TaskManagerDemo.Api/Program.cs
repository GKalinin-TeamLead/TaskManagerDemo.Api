using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TaskManagerDemo.API;
namespace TaskManagerDemo.Api;
public class Program
{
    public static void Main(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>()).Build().Run();
}