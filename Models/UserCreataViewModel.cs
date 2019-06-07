using System.ComponentModel.DataAnnotations;

namespace SkyBlueBlue.Models
{
    public class UserCreateViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName{get;set;}


        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password{get;set;}

    }
}