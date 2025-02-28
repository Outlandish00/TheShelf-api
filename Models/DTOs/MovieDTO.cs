namespace TheShelf.Models.DTOs;

public class MovieDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Actors { get; set; }
    public string PosterLink { get; set; }
    public string Rating { get; set; }
    public string Rated { get; set; }
    public string ReleaseYear { get; set; }
    public string Director { get; set; }
}
