using System.ComponentModel.DataAnnotations;

namespace Co_ParentingApp.Data.Models.RequestModels.Member;

public class CreateMemberRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
}

