using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace Web.App.Models
{

    public class UserProfile : DynamicModel
    {
        public UserProfile() : base("DefaultConnection", "UserProfile", "UserId") { } 
    }

    public class webpages_Membership : DynamicModel
    {
        public webpages_Membership() : base("DefaultConnection", "webpages_Membership", "UserId") { }
    }

    public class webpages_OAuthMembership : DynamicModel
    {
        public webpages_OAuthMembership() : base("DefaultConnection", "webpages_OAuthMembership", "Provider", "ProviderUserId") { }
    }

    public class webpages_Roles : DynamicModel
    {
        public webpages_Roles() : base("DefaultConnection", "webpages_Roles", "RoleId") { }
    }

    public class webpages_UsersInRoles : DynamicModel
    {
        public webpages_UsersInRoles() : base("DefaultConnection", "webpages_UsersInRoles", "UserId", "RoleId") { } 
    }

    /*
SELECT TOP 1000 * from dbo.UserProfile

SELECT TOP 1000 * from dbo.webpages_Membership

SELECT TOP 1000 * from dbo.webpages_OAuthMembership

SELECT TOP 1000 * from dbo.webpages_Roles

SELECT TOP 1000 * from dbo.webpages_UsersInRoles*/

}