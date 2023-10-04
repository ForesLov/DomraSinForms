using DomraSinForms.Application.Questions.Queries.GetList;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Forms.Queries.Get;

public class GetFormQueryHandler : IRequestHandler<GetFormQuery, Option<Form>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public GetFormQueryHandler(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    public async Task<Option<Form>> Handle(GetFormQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms
            .Where(form => form.CreatorId == request.UserId
                        || form.AllowedUsers.Any(user => user.Id == request.UserId))
            .FirstOrDefaultAsync(form => form.Id == request.Id, cancellationToken);

        if (form is null)
            return Option<Form>.None();

        form.Questions = new List<QuestionBase>(await _mediator.Send(new GetQuestionListQuery { FormId = form.Id, }));

        return Option<Form>.Some(form);
    }
}
