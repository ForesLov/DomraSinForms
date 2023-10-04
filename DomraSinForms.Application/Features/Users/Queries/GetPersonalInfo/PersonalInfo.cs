using DomraSinForms.Domain.Identity;

namespace DomraSinForms.Application.Features.Users.Queries.GetPersonalInfo;

public class PersonalInfo
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public static class PersonalInfoExtensions
{
    public static PersonalInfo ToPersonalInfo(this User user)
    {
        return new PersonalInfo
        {
            UserId = user.Id,
            Username = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };
    }
}