using DomraSinForms.Application.Features.Forms.Notifications.Update;
using DomraSinForms.Application.Features.Questions.Notifications;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Questions.Commands.UpdateOptionsQuestion;

internal class UpdateOptionsQuestionCommandHandler : IRequestHandler<UpdateOptionsQuestionCommand, OptionsQuestion?>
{
    private readonly IDatabaseContext _context;
    private readonly IMediator _mediator;

    public UpdateOptionsQuestionCommandHandler(IDatabaseContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<OptionsQuestion?> Handle(UpdateOptionsQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Set<OptionsQuestion>()
            .Include(q => q.Options)
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);
        if (question is null)
            return null;

        question.QuestionText = request.QuestionText;
        question.IsRequired = request.IsRequired;
        question.AllowMultipleChoice = request.AllowMultipleChoice;
        question.Options = request.Options;
        question.Index = request.Index;

        _context.Set<OptionsQuestion>().Update(question);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = question.FormId }, cancellationToken);
        await _mediator.Publish(new UpdateFormNotification { FormId = question.FormId }, cancellationToken);

        return question;
    }
}