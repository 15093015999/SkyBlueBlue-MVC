using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SkyBlueBlue.Models
{
    public class MyInfoModel
    {
        public string id{get;set;}
        public string userName{get;set;}
        public string avatar{get;set;} 
        public IList<string> roles {get;set;}
        public string email{get;set;}
    }
    public class ChangePasswordModel
    {
        [Required]
        [Display(Name = "旧的密码")]
        [DataType(DataType.Password)]
        public string oldPassword{get;set;} 
        [Required]
        [Display(Name = "新的密码")]
        [DataType(DataType.Password)]
        public string newPassword{get;set;}
    }
}