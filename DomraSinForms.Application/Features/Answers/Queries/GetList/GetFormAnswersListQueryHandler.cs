using System.Runtime.CompilerServices;
using AutoMapper;
using DomraSinForms.Application.Answers.Queries.Get;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Answers.Queries.GetList;
public class GetFormAnswersListQueryHandler : IRequestHandler<GetFormAnswersListQuery, IEnumerable<FormAnswersDto>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetFormAnswersListQueryHandler(ApplicationDbContext context, IMapper mapper, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _mediator = mediator;
    }
    public async Task<IEnumerable<FormAnswersDto>> Handle(GetFormAnswersListQuery request, CancellationToken cancellationToken)
    {
        var formAnswersIds = await _context.FormAnswers
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
