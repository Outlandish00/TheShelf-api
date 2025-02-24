using System.ComponentModel.DataAnnotations;

namespace TheShelf.Models;

public class WatchList
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
    public int UserId { get; set; }
    public bool IsPrivate { get; set; }
}
