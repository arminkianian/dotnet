using System.Reflection;
using Serilog;
using Serilog.Core;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

await ConfigureLogging();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(await ConfigureElasticSink(configuration, environment))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

async Task<ElasticsearchSinkOptions> ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    var elasticsearchUri = new Uri(configuration["ElasticConfiguration:Uri"]);

    var connectivityTester = new ElasticsearchConnectivityTester(elasticsearchUri.ToString());
    bool isConnected = await connectivityTester.TestElasticsearchConnectivityAsync();

    if (isConnected)
    {
        return new ElasticsearchSinkOptions(elasticsearchUri)
        {
            AutoRegisterTemplate = true,
            IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment.ToLower()}-{DateTime.Now:yyyy-MM}",
            NumberOfReplicas = 1,
            NumberOfShards = 2
        };
    }
    else
    {
        throw new Exception("Failed to connect to Elasticsearch. Please check your Elasticsearch configuration.");
    }

}
