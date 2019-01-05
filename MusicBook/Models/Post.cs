using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicBook.Models
{
    public class Post
    {
    [Key]
    public int PostId { get; set; }
    [Required]
    public string PostAuthor { get; set; }
    [Required]
    public string AuthorId { get; set; }
    [Required]
    public string PostTopic { get; set; }
    [Required]
    public DateTime PostDate { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    }
}
