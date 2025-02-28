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

    [Required]
    public string Actors { get; set; }

    [Required]
    public string PosterLink { get; set; }

    [Required]
    public string Rating { get; set; }

    [Required]
    public string Rated { get; set; }

    [Required]
    public string ReleaseYear { get; set; }

    [Required]
    public string Director { get; set; }
    public List<WatchListMedia> WatchListMedia { get; set; } = new List<WatchListMedia>();
}
