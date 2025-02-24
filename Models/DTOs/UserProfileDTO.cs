using System.ComponentModel.DataAnnotations.Schema;

namespace TheShelf.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string IdentityUserId { get; set; }
    public string Email { get; set; }

    [NotMapped]
    public List<string> Roles { get; set; }
}
