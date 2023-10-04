using DomraSinForms.Application.Features.Questions.Notifications;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Questions.Commands.Delete;

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
{
    private readonly IDatabaseContext _context;
    private readonly IMediator _mediator;

    public DeleteQuestionCommandHandler(IDatabaseContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.Set<QuestionBase>().FindAsync(request.Id, cancellationToken);

        if (question is null)
            return false;

        var answers = await _context.Set<Answer>().Where(a => a.QuestionId == question.Id).ToArrayAsync();
        _context.Set<Answer>().RemoveRange(answers);
        _context.Set<QuestionBase>().Remove(question);
        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new QuestionsUpdateNotification { FormId = question.FormId }, cancellationToken);

        return true;
    }
}