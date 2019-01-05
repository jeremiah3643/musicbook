using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models
{
    public class Instrument
    {
    [Key]
    public int InstrumentId { get; set; }
    [Required]
    [Display(Name = "Type Of Instrument")]
    public string InstrumentName { get; set; }

    public List<PlayerInstrument> playerInstruments { get; set; }
    }
}
