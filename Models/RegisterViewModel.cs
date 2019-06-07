using System.ComponentModel.DataAnnotations;

namespace SkyBlueBlue.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string userName { get; set; }
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Display(Name = "昵称")]
        public string avatar {get ;set;}
    }
}