using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SkyBlueBlue.Models
{
    public class RoleAddViewModel
    {
        [Required]
        [Display(Name="角色名称")]
        [Remote("CheckRoleExist","Role",ErrorMessage="角色已存在")]
        public string RoleName{get;set;}
    }
}