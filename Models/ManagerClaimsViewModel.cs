using System;
using System.Collections.Generic;

namespace SkyBlueBlue.Models
{
    public class ManagerClaimsViewModel
    {
        public string  UserId { get; set; }
        public string ClaimId{get;set;}
        public List<string> AllClaims { get; set; }
    }
}