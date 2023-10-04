using DomraSinForms.Application.Features.Questions.Queries.GetList;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Forms.Queries.Get;

public class GetFormQueryHandler : IRequestHandler<GetFormQuery, Option<Form>>
{
    private readonly IDatabaseContext _context;
    private readonly IMediator _mediator;

    public GetFormQueryHandler(IDatabaseContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Option<Form>> Handle(GetFormQuery request, CancellationToken cancellationToken)
    {
        var form = await _context.Set<Form>()
            .Where(form => form.CreatorId == request.UserId
                        || form.AllowedUsers.Any(user => user.Id == request.UserId))
            .FirstOrDefaultAsync(form => form.Id == request.Id, cancellationToken);

        if (form is null)
            return Option<Form>.None();

        form.Questions = new List<QuestionBase>(await _mediator.Send(new GetQuestionListQuery { FormId = form.Id, }));

        return Option<Form>.Some(form);
    }
}