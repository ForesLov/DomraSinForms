using System.Collections.Immutable;
using AutoMapper;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Queries.GetList;
public class GetQuestionListQueryHandler : IRequestHandler<GetQuestionListQuery, IEnumerable<QuestionBase>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuestionListQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<QuestionBase>> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .FirstOrDefaultAsync(f => f.Id == request.FormId);
        if (form is null)
            return Array.Empty<QuestionBase>();


        var tqs = _context.TextQuestions
            .Where(q => q.FormId == request.FormId)
            .OrderBy(q => q.Index)
            .AsEnumerable();

        var oqs = _context.OptionsQuestions
            .Where(q => q.FormId == request.FormId)
            .OrderBy(q => q.Index)
            .Include(oq => oq.Options)
            .AsEnumerable();

        var qs = (tqs as IEnumerable<QuestionBase>).Concat(oqs);

        return qs.OrderBy(q => q.Index)
            .ToImmutableList();
    }
}
