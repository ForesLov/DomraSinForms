using DomraSinForms.Application.Features.Answers.Queries.GetList;
using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Answers.Queries.GetEmptyForm;
public class GetEmptyFormQueryHandler : IRequestHandler<GetEmptyFormQuery, FormAnswersDto?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public GetEmptyFormQueryHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<FormAnswersDto?> Handle(GetEmptyFormQuery request, CancellationToken cancellationToken)
    {
        var currentAnswer = await _context.FormAnswers
            .Include(fa => fa.Answers)
            .FirstOrDefaultAsync(fa => fa.FormId == request.FormId && fa.UserId == request.UserId && !fa.IsCompleted, cancellationToken);

        if (currentAnswer is null)
            return await CreateNewCommand(request.FormId, request.UserId, cancellationToken);
        else
            return await UpdateCommand(currentAnswer, cancellationToken);
    }

    private async Task<FormAnswersDto?> CreateNewCommand(string formId, string userId, CancellationToken cancellationToken = default)
    {
        var form = await _context.Forms
            .Include(f => f.Questions)
            .Where(form => !form.IsInArchive)
            .FirstOrDefaultAsync(f => f.Id == formId, cancellationToken);


        if (form is null)
            return null;
        var formAnswers = new FormAnswers
        {
            FormId = formId,
            UserId = userId,
            IsCompleted = false
        };

        await _context.FormAnswers.AddAsync(formAnswers, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);


        var command = new FormAnswersDto
        {
            Id = formAnswers.Id,
            FormId = form.Id,
            UserId = userId,
        };
        var answers = new List<Answer>(form.Questions.Count);

        foreach (var question in form.Questions)
        {
            answers.Add(new Answer { QuestionId = question.Id, Question = question });
        }

        command.Answers = answers;

        return command;
    }
    private async Task<FormAnswersDto?> UpdateCommand(FormAnswers currentFormAnswers, CancellationToken cancellationToken = default)
    {
        var form = await _context.Forms
            .Where(form => !form.IsInArchive)
            .FirstOrDefaultAsync(f => f.Id == currentFormAnswers.FormId, cancellationToken);

        if (form is null)
            return null;
        form.Questions = new List<QuestionBase>(await _mediator.Send(new GetQuestionListQuery { FormId = form.Id, }));
        var command = new FormAnswersDto
        {
            Id = currentFormAnswers.Id,
            FormId = currentFormAnswers.FormId,
            UserId = currentFormAnswers.UserId,
            Answers = currentFormAnswers.Answers
        };

        foreach (var question in form.Questions)
        {
            if (command.Answers.FirstOrDefault(a => a.QuestionId == question.Id) is null)
                command.Answers.Add(new Answer { QuestionId = question.Id, Question = question });
        }

        return command;
    }
}
