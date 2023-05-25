using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Forms.Mvc.Models;

public class EditUserViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    public string Username { get; set; }
    public string? NickName { get; set; } = "";
}
