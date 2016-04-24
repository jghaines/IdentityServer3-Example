using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;

namespace IdentityServer3.ExampleServer.Configuration
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "aman",
                    Password = "pass",
                    Subject = "1",
                    Claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Aman"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Thakral"),
                        new Claim(Constants.ClaimTypes.Email, "a@thakral.in"),
                        new Claim(Constants.ClaimTypes.Role, "developer")
                    }
                }, new InMemoryUser
                {
                    Username = "test",
                    Password = "pass",
                    Subject = "2",
                    Claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Test"),
                        new Claim(Constants.ClaimTypes.FamilyName, "User"),
                        new Claim(Constants.ClaimTypes.Email, "test@test.com"),
                        new Claim(Constants.ClaimTypes.Role, "developer")
                    }
                },
                
            };
        }
    }
}