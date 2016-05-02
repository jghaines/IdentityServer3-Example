using IdentityServer3.Core;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Configuration.Hosting;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;
using IdentityServer3.ExampleServer;
using IdentityServer3.ExampleServer.Configuration;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
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
                    var inMem = new InMemoryCorsPolicyService(Clients.Get());

                    var factory = new IdentityServerServiceFactory()
                        .UseInMemoryClients(Clients.Get())
                        .UseInMemoryScopes(Scopes.Get())
                        .UseInMemoryUsers(Users.Get());

                    factory.CorsPolicyService = new Registration<ICorsPolicyService>(inMem);

                    coreApp.UseIdentityServer(new IdentityServerOptions
                    {
                        SiteName = "Standalone Identity Server",
                        SigningCertificate = Cert.Load(),
                        Factory = factory,
                        RequireSsl = true,

                    });

                });


        }
    }
}