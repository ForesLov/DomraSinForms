using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Versions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Users.Queries.GetUserActionsSummary;

public class GetUserActionsSummaryQueryHandler : IRequestHandler<GetUserActionsSummaryQuery, UsersActionsSummary?>
{
    private readonly IDatabaseContext _context;

    public GetUserActionsSummaryQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<UsersActionsSummary?> Handle(GetUserActionsSummaryQuery request, CancellationToken cancellationToken)
    {
        var result = new UsersActionsSummary();

        result.Forms = await _context.Set<Form>().Where(f => f.CreatorId == request.UserId).ToArrayAsync(cancellationToken);
        result.FormAnswers = await _context.Set<FormAnswers>().Include(fa => fa.Form).Where(f => f.UserId == request.UserId && f.IsCompleted).ToArrayAsync(cancellationToken);
        result.FormVersions = await _context.Set<FormVersion>().Where(f => f.Form.CreatorId == request.UserId).ToArrayAsync(cancellationToken);

        return result;
    }
}