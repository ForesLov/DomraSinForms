using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Answers.Commands.Complete;

public class CompleteFormAnswersCommandHandler : IRequestHandler<CompleteFormAnswersCommand, FormAnswers?>
{
    private readonly IDatabaseContext _context;

    public CompleteFormAnswersCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<FormAnswers?> Handle(CompleteFormAnswersCommand request, CancellationToken cancellationToken)
    {
        var formAnswers = await _context.Set<FormAnswers>()
            .Include(x => x.Answers)
            .FirstOrDefaultAsync(fa => fa.UserId == request.UserId && fa.FormId == request.FormId && !fa.IsCompleted, cancellationToken);

        if (formAnswers is null)
            return null;

        if (formAnswers.IsCompleted)
            return formAnswers;

        var form = await _context.Set<Form>()
            .Include(x => x.Questions)
            .Include(f => f.Version)
            .FirstOrDefaultAsync(fa => fa.Id == formAnswers.FormId);

        if (form is null)
            return null;

        foreach (var question in form.Questions)
        {
            var answer = formAnswers.Answers.FirstOrDefault(q => q.QuestionId == question.Id);
            if (answer is not null)
            {
                if (question.IsRequired && string.IsNullOrWhiteSpace(answer.Value))
                    return null;
            }
            else
                return null;
        }

        formAnswers.IsCompleted = true;
        formAnswers.CreationDate = DateTime.UtcNow;
        //formAnswers.FormVersionId = form.Version?.Id;

        _context.Set<FormAnswers>().Update(formAnswers);
        await _context.SaveChangesAsync(cancellationToken);

        return formAnswers;
    }
}