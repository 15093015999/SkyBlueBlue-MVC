using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SkyBlueBlue.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Claims = new List<IdentityUserClaim<string>>();
            Logins = new List<IdentityUserLogin<string>>();
            Tokens = new List<IdentityUserToken<string>>();
            UserRoles = new List<IdentityUserRole<string>>();
        }
        public ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public ICollection<IdentityUserRole<string>> UserRoles { get; set; }
        public string avatar { get; set; }
        // public string school {get;set;}
        // public string StudentNo {get;set;}
    }
}