using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace IdentityServer3.ExampleServer.Configuration
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = @"implicitclient",
                    ClientName = @"Example Implicit Client",
                    Enabled = true,
                    Flow = Flows.Implicit,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44304/account/signInCallback",
                        "http://localhost:44305/",
                        "http://localhost:44305/index.html",
                        "https://dev-oauth-client.azurewebsites.net/account/signInCallback",
                        "https://basicoauthclient.azurewebsites.net/",
                        "https://basicoauthclient.azurewebsites.net/index.html",
                        "https://angular-oauthclient.azurewebsites.net/",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44304/",
                        "http://localhost:44305/",
                        "http://localhost:44305/index.html",
                        "https://dev-oauth-client.azurewebsites.net/",
                        "https://basicoauthclient.azurewebsites.net/",
                        "https://angular-oauthclient.azurewebsites.net/",

                    },
                    AllowedScopes =
                        new List<string>
                        {
                            Constants.StandardScopes.OpenId,
                            Constants.StandardScopes.Profile,
                            Constants.StandardScopes.Email,
                            "read",
                            "write",
                            "email"

                        },
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedCorsOrigins =
                    {
                        "https://localhost:44304",
                        "https://localhost:44305",
                        "http://localhost:44305",
                        "https://dev-oauth-client.azurewebsites.net",
                        "http://dev-oauth-client.azurewebsites.net",
                        "https://basicoauthclient.azurewebsites.net",
                        "https://angular-oauthclient.azurewebsites.net",
                    }

                },
                new Client
                {
                    ClientId = @"hybridclient",
                    ClientName = @"Example Hybrid Client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("idsrv3test".Sha256())
                    },
                    Enabled = true,
                    Flow = Flows.Hybrid,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44305/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44305/"
                    },
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.OfflineAccess
                    },
                    AccessTokenType = AccessTokenType.Jwt
                }
            };
        }
    }
}