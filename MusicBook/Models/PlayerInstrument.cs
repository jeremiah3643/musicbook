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
        public int PlayerInstrumentId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    
        [Required]
        public int InstrumentId { get; set; }


        public Instrument Instrument { get; set; }


        public ApplicationUser ApplicationUser { get; set; }


    }
}
