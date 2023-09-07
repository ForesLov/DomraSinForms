using DomraSinForms.Application.Forms.Notifications.Update;
using DomraSinForms.Application.Questions.Notifications;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Commands.CreateOptionsQuestion;
public class CreateOptionsQuestionCommandHandler : IRequestHandler<CreateOptionsQuestionCommand, OptionsQuestion?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public CreateOptionsQuestionCommandHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<OptionsQuestion?> Handle(CreateOptionsQuestionCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
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

        _context.Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = form.Id }, cancellationToken);
        await _mediator.Publish(new UpdateFormNotification { FormId = form.Id }, cancellationToken);

        return question;
    }
}
