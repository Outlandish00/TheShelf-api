namespace TheShelf.Models;

public class WatchListMedia
{
    public int Id { get; set; }
    public int WatchListId { get; set; }
    public int MovieId { get; set; }

    public WatchList Watchlist { get; set; }
    public Movie Movie { get; set; }
}
