using System.ComponentModel.DataAnnotations;

namespace TheShelf.Models;

public class Movie
{
    public int Id { get; set; }
    public int UserId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Genre { get; set; }
}
