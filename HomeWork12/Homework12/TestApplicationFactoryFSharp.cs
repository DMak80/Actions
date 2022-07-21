using Hw6;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Homework12;

public class TestApplicationFactoryFSharp : WebApplicationFactory<App.Startup>
{
    protected override IHostBuilder CreateHostBuilder()
        => Host
            .CreateDefaultBuilder()
            .ConfigureWebHostDefaults(a => a
                .UseStartup<App.Startup>()
                .UseTestServer());
}