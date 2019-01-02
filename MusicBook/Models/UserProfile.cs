using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MusicBook.Models
{
    public class UserProfile
    {
        [Key]
        public int UserProfileId { get; set; }

      
        public ApplicationUser applicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Location { get; set; }

        public string Experience { get; set; }

        public ICollection<Instrument> PlayedInstruments { get; set; }

    }
}

