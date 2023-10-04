using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Forms.Queries.GetMin;

public class GetMinFormQueryHandler : IRequestHandler<GetMinFormQuery, Option<Form>>
{
    private readonly IDatabaseContext _context;

    public GetMinFormQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Option<Form>> Handle(GetMinFormQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Set<Form>()
            .FirstOrDefaultAsync(form => form.Id == request.Id, cancellationToken);
        return Option<Form>.Some(form);
    }
}