using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Answers.Queries.GetQuestionAnswers;

public class GetQuestionAnswersQueryHandler : IRequestHandler<GetQuestionAnswersQuery, IEnumerable<Answer>>
{
    private readonly ApplicationDbContext _context;

    public GetQuestionAnswersQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Answer>> Handle(GetQuestionAnswersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Answers
            .Where(a => a.QuestionId == request.QuestionId)
            .ToArrayAsync(cancellationToken);
    }
}