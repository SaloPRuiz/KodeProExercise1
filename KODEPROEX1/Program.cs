using KODEPROEX1.Implementation.Interfaces;
using KODEPROEX1.Implementation.Repositories;
using KODEPROEX1.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KODEPROEX1;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        
        // DEPENDENCY INJECTION - CONFIGURATION
        // Here we configure the services that the application will use
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddScoped<IStudentRepo, StudentRepo>(); // Our interface
                services.AddDbContext<KODEPROExerciseContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("KODEPROCmd"))); // Our connection to database
                services.AddTransient<Form1>(); // We register our form as a service
            })
            .Build();

        // We create the scope to manage the lifetime of our services
        using var serviceScope = host.Services.CreateScope();
        var services = serviceScope.ServiceProvider;

        var form = services.GetRequiredService<Form1>();
        
        Application.Run(form);
    }
}