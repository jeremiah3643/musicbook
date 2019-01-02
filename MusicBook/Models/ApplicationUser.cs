using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models
{
    public class ApplicationUser : IdentityUser
    {
    public ApplicationUser()
    {}

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Experience { get; set; }

        public List<PlayerInstrument> playerInstruments { get; set; }
    }
}

