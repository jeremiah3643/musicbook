using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models
{
    public class Thread
    {
    [Key]
    public int ThreadId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public Post Post { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public ApplicationUser Author { get; set; }
        [Required]
        public string ThreadMessage { get; set; }
        [Required]
        public DateTime ThreadDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

    }
}
