using System.ComponentModel.DataAnnotations;

namespace Commander.API.Models
{
    public class Command
    {
     
        public int Id { get; set; }
     
        
        public string HowTo { get; set; }
      
        public string Line { get; set; }
     
        public string PlatForm { get; set; }
    }
}