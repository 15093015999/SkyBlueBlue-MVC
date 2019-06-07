using System.ComponentModel.DataAnnotations;
namespace SkyBlueBlue.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "账号")]
        public string userName { get; set; }
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}