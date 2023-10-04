using AutoMapper;
using DomraSinForms.Domain.Models;
using DomraSinForms.Persistence;

using MediatR;

namespace DomraSinForms.Application.Features.Forms.Commands.Create;
public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, Form>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateFormCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Form> Handle(CreateFormCommand request, CancellationToken cancellationToken)
    {
        var form = _mapper.Map<Form>(request);
        form.CreationDate = DateTime.UtcNow;

        await _context.Forms.AddAsync(form, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return form;
    }
}
