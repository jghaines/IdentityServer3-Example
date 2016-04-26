using System.Security.Policy;
using IdentityServer3.Core.Configuration;
using IdentityServer3.ExampleServer;
using IdentityServer3.ExampleServer.Configuration;
using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup("InMemory", typeof(Startup))]

namespace IdentityServer3.ExampleServer
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug() // change with your desired log level
            .WriteTo.File(@"C:\myPath.txt") // remember to assign proper writing privileges on the file
            .CreateLogger();

            app.Map(
                "/oauth/ls",
                coreApp =>
                {
                    coreApp.UseIdentityServer(new IdentityServerOptions
                    {
                        SiteName = "Standalone Identity Server",
                        SigningCertificate = Cert.Load(),
                        Factory =
                        new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get()),
                        RequireSsl = true,
                        LoggingOptions = new LoggingOptions() {
                            EnableHttpLogging = true,
                            EnableKatanaLogging = true,
                            EnableWebApiDiagnostics = true,
                            WebApiDiagnosticsIsVerbose = true,
                        }
                    });

                });
        }
    }
}