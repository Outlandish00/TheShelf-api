using System.ComponentModel.DataAnnotations;

namespace TheShelf.Models;

public class MovieDTO
{
    public int Id { get; set; }

    [Required]
    public string imbdId { get; set; }
    public List<WatchListMedia> WatchListMedia { get; set; } = new List<WatchListMedia>();
}
