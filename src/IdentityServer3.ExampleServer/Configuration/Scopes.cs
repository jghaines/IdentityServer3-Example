﻿using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityServer3.ExampleServer.Configuration
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Roles,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.OfflineAccess,
                new Scope() {Name = "write"},
                new Scope() {Name = "read"},
                new Scope() {Name = "email"},
            };
        }
    }
}