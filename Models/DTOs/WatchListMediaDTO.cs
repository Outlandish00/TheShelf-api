namespace TheShelf.Models.DTOs;

public class WatchListMediaDTO
{
    public int Id { get; set; }
    public int WatchListId { get; set; }
    public int MovieId { get; set; }
    public WatchListDTO? Watchlist { get; set; }
    public MovieDTO? Movie { get; set; }
}
