namespace TheShelf.Models.DTOs;

public class MediaCommentDTO
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public int MediaId { get; set; }
    public string Body { get; set; }
}
