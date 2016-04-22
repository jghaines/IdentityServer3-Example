using IdentityServer3.Core.Configuration;
using IdentityServer3.ExampleServer;
using IdentityServer3.ExampleServer.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("InMemory", typeof(Startup))]

namespace IdentityServer3.ExampleServer
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
                        RequireSsl = true
                    });
                });
        }
    }
}