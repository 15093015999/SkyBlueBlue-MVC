using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkyBlueBlue.Models
{
    public class UserUpdateViewModel
    {
        [Required]
        [Display(Name = "编号")]
        public string Id{get;set;}

        [Required]
        [Display(Name = "用户名")]
        public string UserName{get;set;}


        public List<string> Claims{get;set;}

    }
}