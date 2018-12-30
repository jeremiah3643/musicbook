using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models
{
    public class PlayerInstrument
    {
    [Key]
    public int ApplicationUserId { get; set; }
    
    [Required]
    public int InstrumentId { get; set; }
    [Required]
    public Instrument Instrument { get; set; }

    [Required]
    public string UserId { get; set; }
    [Required]
    public ApplicationUser User { get; set; }
    }
}
