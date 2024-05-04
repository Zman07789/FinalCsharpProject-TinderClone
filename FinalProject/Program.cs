using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Configuration; 
using FinalCsharpProject;
using FinalProject.csproj;
//This code sets up the program entry point for the ASP.NET Core web application, 
// configuring the host and specifying the startup class.

{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
