using System.ComponentModel.DataAnnotations;

namespace SkyBlueBlue.Models
{
    public class SuccessModel
    {
        [Key]
        public int id{get;set;}
        public string userName{get;set;}
        public string paper{get;set;} 
        public int scores{get;set;}
        public int subtotal{get;set;}
    }
}