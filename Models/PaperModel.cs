using System.ComponentModel.DataAnnotations;

namespace SkyBlueBlue.Models
{
    public class PaperModel
    {
        [Key]
        public int id {get;set;}
        [Required]
        public string title{get;set;}
        [Required]
        public string body{get;set;}
        [Required]
        public string teacherUserName{get;set;}
        [Required]
        public int subtotal{get;set;}
    }
}