using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel.Constants;
using IdentityServer3.WsFederation.Models;

namespace IdentityServer3.ExampleServer.Configuration
{
    public static class RelyingParties
    {
        public static IEnumerable<RelyingParty> Get()
        {
            return new List<RelyingParty>
                       {
                           new RelyingParty
                               {
                                   Realm = "urn:testClient", 
                                   Name = "testclient", 
                                   Enabled = true, 
                                   ReplyUrl = "https://localhost:4004/TestClient/", 
                                   TokenType = TokenTypes.Saml2TokenProfile11, 
                                   ClaimMappings =
                                       new Dictionary<string, string>
                                           {
                                               { "sub", ClaimTypes.NameIdentifier }, 
                                               { "name", ClaimTypes.Name }, 
                                               { "given_name", ClaimTypes.GivenName }, 
                                               { "family_name", ClaimTypes.Surname }, 
                                               { "email", ClaimTypes.Email }, 
                                               { "upn", ClaimTypes.Upn }
                                           }
                               }
                       };
        }
    }
}