using System.ComponentModel.DataAnnotations;

namespace PregnancySMS.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string MessageText { get; set; }
        public int? NextMessageId { get; set; }
    }
}