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
    public int Id { get; set; }

    [Required]
    public string ApplicationUserId { get; set; }

    [Required]
    public string SenderId { get; set; }

    
    public ApplicationUser ApplicationUser { get; set; }
    }
}
