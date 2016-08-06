using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CAD_API.Filters
{
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid UserId { get; set; }

        public BasicAuthenticationIdentity(string userName, string password, Guid? userId = null)
            : base(userName, "Basic")
        {
            UserName = userName;
            Password = password;
            UserId = (Guid)userId;
        }
    }
}