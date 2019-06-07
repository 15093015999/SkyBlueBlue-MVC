using System.ComponentModel.DataAnnotations;

namespace SkyBlueBlue.Models
{
    public class TestModel
    {
        public int id { get; set; }
        
        [Required]
        [Display(Name = "题目")]
        public string title { get; set; }
        [Required]
        [Display(Name = "题目类型")]
        public string type { get; set; }
        [Required]
        [Display(Name = "内容")]
        public string content { get; set; }
        [Required]
        [Display(Name = "分值")]
        public string scores { get; set; }
    }
}