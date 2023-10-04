using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Questions.Queries.Get;

public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionBase?>
{
    private readonly IDatabaseContext _context;

    public GetQuestionQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<QuestionBase?> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        var questionBase = await _context.Set<QuestionBase>().FindAsync(request.Id, cancellationToken);
        switch (questionBase)
        {
            case TextQuestion:
                return await _context.Set<TextQuestion>().FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

            case OptionsQuestion:
                return await _context.Set<OptionsQuestion>().Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);
        }

        return null;
    }
}