using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models.Answers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Answers.Queries.GetQuestionAnswers;

public class GetQuestionAnswersQueryHandler : IRequestHandler<GetQuestionAnswersQuery, IEnumerable<Answer>>
{
    private readonly IDatabaseContext _context;

    public GetQuestionAnswersQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Answer>> Handle(GetQuestionAnswersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Set<Answer>()
            .Where(a => a.QuestionId == request.QuestionId)
            .ToArrayAsync(cancellationToken);
    }
}