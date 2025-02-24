using System.ComponentModel.DataAnnotations;

namespace TheShelf.Models;

public class MediaComment
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public int MediaId { get; set; }

    [Required]
    public string Body { get; set; }
}
