using Homework8;

Host
    .CreateDefaultBuilder()
    .ConfigureWebHostDefaults(hostBuilder =>
        hostBuilder.UseStartup<Startup>())
    .Build()
    .Run();