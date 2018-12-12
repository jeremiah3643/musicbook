using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models
{
    public class MessageBox
    {
    [Key]
    public int MessageBoxId { get; set; }

    [Required]
    public string RecipientId { get; set; }
    [Required]
    public ApplicationUser Recipient { get; set; }


    [Required]
    public string SenderId { get; set; }
    [Required]
    public ApplicationUser Sender { get; set; }

    [Required]
    public int MessageId { get; set; }
    }
}
