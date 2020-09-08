using System.ComponentModel.DataAnnotations;

namespace Commander.API.Dtos
{
    public class CommandUpdateDTO
    {


        [Required]
        [MaxLength(200)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string PlatForm { get; set; }
    }
}