using DomraSinForms.Application.Features.Forms.Notifications.Update;
using DomraSinForms.Application.Features.Questions.Notifications;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Questions.Commands.CreateOptionsQuestion;

public class CreateOptionsQuestionCommandHandler : IRequestHandler<CreateOptionsQuestionCommand, OptionsQuestion?>
{
    private readonly IDatabaseContext _context;
    private readonly IMediator _mediator;

    public CreateOptionsQuestionCommandHandler(IDatabaseContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<OptionsQuestion?> Handle(CreateOptionsQuestionCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Set<Form>()
            .Include(x => x.Questions)
            .FirstOrDefaultAsync(f => f.Id == request.FormId, cancellationToken);

        if (form == null)
            return null;

        var question = new OptionsQuestion
        {
            QuestionText = request.QuestionText,
            AllowMultipleChoice = request.AllowMultipleChoice,
            Options = request.Options,
            Index = form.Questions.Count + 1,
            IsRequired = request.IsRequired,
        };

        form.Questions.Add(question);

        _context.Set<Form>().Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = form.Id }, cancellationToken);
        await _mediator.Publish(new UpdateFormNotification { FormId = form.Id }, cancellationToken);

        return question;
    }
}