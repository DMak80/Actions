using System;
using System.Linq;
using Homework10.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hw10Tests;

public class TestApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(serviceCollection =>
        {
            var dbDescriptor = serviceCollection.SingleOrDefault(
                descriptor => descriptor.ServiceType == typeof(DbContextOptions<ApplicationContext>));
            serviceCollection.Remove(dbDescriptor!);
            
            var nameTestDb = Guid.NewGuid().ToString();
            serviceCollection.AddDbContext<ApplicationContext>(
                optionsBuilder => optionsBuilder.UseInMemoryDatabase(nameTestDb));
        });

        base.ConfigureWebHost(builder);
    }
}