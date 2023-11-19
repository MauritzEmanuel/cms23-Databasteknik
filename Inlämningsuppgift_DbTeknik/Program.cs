using Inlämningsuppgift_DbTeknik.Contexts;
using Inlämningsuppgift_DbTeknik.Menus;
using Inlämningsuppgift_DbTeknik.Repositories;
using Inlämningsuppgift_DbTeknik.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inlämningsuppgift_DbTeknik;

internal class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Databasteknik\Inlämningsuppgift_DbTeknik\Inlämningsuppgift_DbTeknik\Contexts\Assignment_Db.mdf;Integrated Security=True;Connect Timeout=30"));


        //Repositories
        services.AddScoped<AddressRepo>();
        services.AddScoped<CustomerRepo>();


        //Services
        services.AddScoped<CustomerService>();


        //Menus
        services.AddScoped<CustomerMenu>();
        services.AddScoped<MainMenu>();



        var sp = services.BuildServiceProvider();
        var mainMenu = sp.GetRequiredService<MainMenu>();
        await mainMenu.StartAsync();
    }


}