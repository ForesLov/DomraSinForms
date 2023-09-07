using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Users.Queries;
public class GetUserActionsSummaryQueryHandler : IRequestHandler<GetUserActionsSummaryQuery, UsersActionsSummary?>
{
    private readonly ApplicationDbContext _context;

    public GetUserActionsSummaryQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<UsersActionsSummary?> Handle(GetUserActionsSummaryQuery request, CancellationToken cancellationToken)
    {
        var result = new UsersActionsSummary();

        result.Forms = await _context.Forms.Where(f => f.CreatorId == request.UserId).ToArrayAsync();
        result.FormAnswers = await _context.FormAnswers.Include(fa => fa.Form).Where(f => f.UserId == request.UserId && f.IsCompleted).ToArrayAsync();
        result.FormVersions = await _context.FormVersions.Where(f => f.Form.CreatorId == request.UserId).ToArrayAsync();

        return result;
    }
}
