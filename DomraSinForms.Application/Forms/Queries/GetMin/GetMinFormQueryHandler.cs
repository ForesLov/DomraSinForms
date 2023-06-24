using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Forms.Queries.GetMin;

public class GetMinFormQueryHandler : IRequestHandler<GetMinFormQuery, Option<Form>>
{
    private readonly ApplicationDbContext _context;

    public GetMinFormQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Option<Form>> Handle(GetMinFormQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .FirstOrDefaultAsync(form => form.Id == request.Id, cancellationToken);
        return Option<Form>.Some(form);
    }
}