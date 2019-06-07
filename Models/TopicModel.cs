using System.ComponentModel.DataAnnotations;

namespace SkyBlueBlue.Models
{
    // public interface ITopicModel
    // {
    //     int id { get; set; }
    //     string title { get; set; }
    //     string type { get; set;}
    //     string content { get; set; }
    //     string answe { get; set; }
    //     string scores { get; set; }
    // }
    public class TopicModel
    {
        [Key]
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
        [Display(Name = "答案")]
        public string answe { get; set; }
        [Required]
        [Display(Name = "分值")]
        public int scores { get; set; }
        
    }
    // public  class ChoiceTopicModel:ITopicModel
    // {
    //     public int id { get; set; }
    //     public string title { get; set; }
    //     public string type { get; set;}
    //     public string answe { get; set; }
    //     public string scores { get; set; }
    //     public string content { get; set; }
    //     public string optionA{get;set;}
    //     public string optionB{get;set;}
    //     public string optionC{get;set;}
    //     public string optionD{get;set;}

    // }
    // public  class FillTopicModel:ITopicModel
    // {
    //     public  int id { get; set; }
    //     public string title { get; set; }
    //     public string type { get; set;}
    //     public string content { get; set; }
    //     public string answe { get; set; }
    //     public string scores { get; set; }
    // }
    // public  class JudgeTopicModel:ITopicModel
    // {
    //     public int id { get; set; }
    //     public string title { get; set; }
    //     public string type { get; set;}
    //     public string content { get; set; }
    //     public string answe { get; set; }
    //     public string scores { get; set; }
    // }
}