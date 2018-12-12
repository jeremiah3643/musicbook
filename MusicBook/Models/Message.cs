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
    public string UserId { get; set; }
    [Required]
    public ApplicationUser User { get; set; }


    public int ParentId { get; set; }
    public Message ParentMessage { get; set; }


    public string Subject { get; set; }
    [Required]
    public string MessageBody { get; set; }
    }
}
