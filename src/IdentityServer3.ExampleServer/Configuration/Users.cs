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
                    Password = "Password123",
                    Subject = "1",
                    Claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.GivenName, "Aman"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Thakral"),
                        new Claim(Constants.ClaimTypes.Email, "a@thakral.in"),
                        new Claim(Constants.ClaimTypes.Role, "developer")
                    }
                }
            };
        }
    }
}