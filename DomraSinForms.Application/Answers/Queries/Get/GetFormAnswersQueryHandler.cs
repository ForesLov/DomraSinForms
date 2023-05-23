using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Answers.Queries.Get
{
    public class GetFormAnswersQueryHandler : IRequestHandler<GetFormAnswersQuery, FormAnswers?>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMediator _mediator;

        public GetFormAnswersQueryHandler(ApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<FormAnswers?> Handle(GetFormAnswersQuery request, CancellationToken cancellationToken)
        {
            var formAnswers = await _context.FormAnswers
                .Include(f => f.Answers)
                .Include(f => f.User)
                .Include(f => f.FormVersion)
                .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            if (formAnswers is null)
                return null;

            var questions = await _mediator.Send(new GetQuestionListQuery { FormId = formAnswers.FormId, });

            foreach (var question in questions)
            {
                var answer = formAnswers.Answers.FirstOrDefault(a => a.QuestionId == question.Id);
                if (answer is not null)
                    answer.Question = question;
            }
            return formAnswers;
        }
    }
}
