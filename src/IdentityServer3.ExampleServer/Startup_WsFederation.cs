using System.Collections.Generic;
using IdentityServer3.Core.Configuration;
using IdentityServer3.ExampleServer;
using IdentityServer3.ExampleServer.Configuration;
using IdentityServer3.WsFederation.Configuration;
using IdentityServer3.WsFederation.Models;
using IdentityServer3.WsFederation.Services;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("WsFederation", typeof(Startup_WsFederation))]

namespace IdentityServer3.ExampleServer
{
    public sealed class Startup_WsFederation
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/core",
                coreApp =>
                    {
                        coreApp.UseIdentityServer(
                            new IdentityServerOptions
                                {
                                    SiteName = "Standalone Identity Server",
                                    SigningCertificate = Cert.Load(),
                                    Factory =
                                        new IdentityServerServiceFactory().UseInMemoryClients(Clients.Get())
                                        .UseInMemoryScopes(Scopes.Get())
                                        .UseInMemoryUsers(Users.Get()),
                                    RequireSsl = true,
                                    PluginConfiguration = ConfigureWsFederation
                                });
                    });
        }

        private void ConfigureWsFederation(IAppBuilder pluginApp, IdentityServerOptions options)
        {
            var factory = new WsFederationServiceFactory(options.Factory);
            factory.Register(new Registration<IEnumerable<RelyingParty>>(RelyingParties.Get()));
            factory.RelyingPartyService = new Registration<IRelyingPartyService>(typeof(InMemoryRelyingPartyService));
            pluginApp.UseWsFederationPlugin(new WsFederationPluginOptions { IdentityServerOptions = options, Factory = factory });
        }
    }
}