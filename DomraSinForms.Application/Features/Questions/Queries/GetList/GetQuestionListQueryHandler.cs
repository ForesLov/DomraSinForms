using System.Collections.Immutable;
using AutoMapper;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Forms.Questions.Types;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Questions.Queries.GetList;

public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, IEnumerable<QuestionBase>>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetQuestionListQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<QuestionBase>> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Set<Form>()
            .FirstOrDefaultAsync(f => f.Id == request.FormId);
        if (form is null)
            return Array.Empty<QuestionBase>();

        var tqs = _context.Set<TextQuestion>()
            .Where(q => q.FormId == request.FormId)
            .OrderBy(q => q.Index)
            .AsEnumerable();

        var oqs = _context.Set<OptionsQuestion>()
            .Where(q => q.FormId == request.FormId)
            .OrderBy(q => q.Index)
            .Include(oq => oq.Options)
            .AsEnumerable();

        var qs = (tqs as IEnumerable<QuestionBase>).Concat(oqs);

        return qs.OrderBy(q => q.Index)
            .ToImmutableList();
    }
}