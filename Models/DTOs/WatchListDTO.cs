namespace TheShelf.Models.DTOs;

public class WatchListDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
    public bool IsPrivate { get; set; }

    //Navigation Properties
    public List<WatchListMediaDTO> WatchlistMedia { get; set; }
}
