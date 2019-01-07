using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models
{
    public class Message
    {
    [Key]
    public int MessageId { get; set; }
    
    [Required]
    public string MessageBoxId { get; set; }

    [Required]
    public string SendToId { get; set; }

    [Required]
    public string SentFromId { get; set; }
  


    public Message ParentMessage { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string MessageBody { get; set; }


    public ApplicationUser ApplicationUser { get; set; }
    public List<MessageBox> messageBoxes { get; set; }

    }
}
