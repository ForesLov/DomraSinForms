using System.Runtime.CompilerServices;
using AutoMapper;
using DomraSinForms.Application.Features.Answers.Queries.Get;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models.Answers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Answers.Queries.GetList;

public class GetFormAnswersListQueryHandler : IRequestHandler<GetFormAnswersListQuery, IEnumerable<FormAnswersDto>>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetFormAnswersListQueryHandler(IDatabaseContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<FormAnswersDto>> Handle(GetFormAnswersListQuery request, CancellationToken cancellationToken)
    {
        var formAnswersIds = await _context.Set<FormAnswers>()
            .Where(fa => fa.FormId == request.FormId && fa.IsCompleted)
            .Select(fa => fa.Id)
            .ToArrayAsync(cancellationToken);

        var result = new List<FormAnswersDto>(formAnswersIds.Length);
        await foreach (var fa in Handle(formAnswersIds, cancellationToken))
        {
            result.Add(_mapper.Map<FormAnswersDto>(fa));
        }
        return result;
    }

    private async IAsyncEnumerable<FormAnswers> Handle(IEnumerable<string> ids, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (var id in ids)
        {
            yield return _mapper.Map<FormAnswers>(await _mediator.Send(new GetFormAnswersQuery { Id = id }, cancellationToken));
        }
    }
}