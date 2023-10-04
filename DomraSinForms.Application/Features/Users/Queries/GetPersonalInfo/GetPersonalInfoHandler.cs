using DomraSinForms.Domain.Identity;
using DomraSinForms.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Users.Queries.GetPersonalInfo;

public class GetPersonalInfoHandler : IRequestHandler<GetPersonalInfo, Option<PersonalInfo>>
{
    private readonly UserManager<User> _userManager;
    private readonly IDatabaseContext _context;

    public GetPersonalInfoHandler(UserManager<User> userManager, IDatabaseContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<Option<PersonalInfo>> Handle(GetPersonalInfo request, CancellationToken cancellationToken)
    {
        var user = await _context.Set<User>().FirstOrDefaultAsync(user => user.Id == request.UserId, cancellationToken);
        return Option<User>.Some(user).Map(u => u.ToPersonalInfo());
    }
}