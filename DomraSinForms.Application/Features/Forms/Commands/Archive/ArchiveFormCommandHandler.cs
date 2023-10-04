using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Forms.Commands.Archive;

public class ArchiveFormCommandHandler : IRequestHandler<ArchiveFormCommand, Form?>
{
    private readonly IDatabaseContext _context;

    public ArchiveFormCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Form?> Handle(ArchiveFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Set<Form>().FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (form is null)
            return null;

        form.IsInArchive = true;

        _context.Set<Form>().Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        return form;
    }
}