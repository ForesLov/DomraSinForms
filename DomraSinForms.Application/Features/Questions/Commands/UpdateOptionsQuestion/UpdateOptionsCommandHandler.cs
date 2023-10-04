using DomraSinForms.Application.Features.Forms.Notifications.Update;
using DomraSinForms.Application.Features.Questions.Notifications;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Questions.Commands.UpdateOptionsQuestion;

internal class UpdateOptionsCommandHandler : IRequestHandler<UpdateOptionsQuestionCommand, OptionsQuestion?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateOptionsCommandHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<OptionsQuestion?> Handle(UpdateOptionsQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.OptionsQuestions
            .Include(q => q.Options)
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);
        if (question is null)
            return null;

        question.QuestionText = request.QuestionText;
        question.IsRequired = request.IsRequired;
        question.AllowMultipleChoice = request.AllowMultipleChoice;
        question.Options = request.Options;
        question.Index = request.Index;

        _context.Update(question);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = question.FormId }, cancellationToken);
        await _mediator.Publish(new UpdateFormNotification { FormId = question.FormId }, cancellationToken);

        return question;
    }
}