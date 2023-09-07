using DomraSinForms.Application.Forms.Notifications.Update;
using DomraSinForms.Application.Questions.Notifications;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;

namespace DomraSinForms.Application.Questions.Commands.UpdateTextQuestion;
public class UpdateTextQuestionCommandHandler : IRequestHandler<UpdateTextQuestionCommand, TextQuestion?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UpdateTextQuestionCommandHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<TextQuestion?> Handle(UpdateTextQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.TextQuestions.FindAsync(request.Id, cancellationToken);

        if (question is null)
            return null;

        question.QuestionText = request.QuestionText;
        question.IsRequired = request.IsRequired;
        question.Index = request.Index;
        question.Type = request.Type;

        _context.Update(question);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = question.FormId }, cancellationToken);
        await _mediator.Publish(new UpdateFormNotification { FormId = question.FormId }, cancellationToken);

        return question;
    }
}
