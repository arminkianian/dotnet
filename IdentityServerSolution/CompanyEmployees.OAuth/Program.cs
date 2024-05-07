using CompanyEmployees.OAuth.Configuration;

namespace CompanyEmployees.OAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIdentityServer()
                .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
                .AddTestUsers(InMemoryConfig.GetUsers())
                .AddInMemoryClients(InMemoryConfig.GetClients())
                .AddDeveloperSigningCredential(); //not something we want to use in a production environment;

            var app = builder.Build();

            app.UseIdentityServer();

            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
