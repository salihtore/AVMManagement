using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AVM.Core.Entities
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int SenderId { get; set; }
        
        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }

        public int ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual User Receiver { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime SentDate { get; set; }

        public bool IsRead { get; set; }
    }
}
