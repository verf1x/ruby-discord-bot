using RubyBot.Worker.Configuration;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting Ruby Discord Bot...");

    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

    string environment = builder.Environment.EnvironmentName;

    builder.Configuration.AddJsonFile($"appsettings.{environment}.json", true, true);

    builder.Configuration.AddEnvironmentVariables();

    builder.Services.AddConfiguration(builder.Configuration);

    IHost host = builder.Build();

    host.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Ruby Discord Bot terminated unexpectedly");
}
finally
{
    await Log.CloseAndFlushAsync();
}

public partial class Program;