namespace TheShelf.Models;

public class MovieRating
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public int Rating { get; set; }
}
