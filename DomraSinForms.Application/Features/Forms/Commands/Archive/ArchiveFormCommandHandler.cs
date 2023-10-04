using DomraSinForms.Domain.Models;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Forms.Commands.Archive;

public class ArchiveFormCommandHandler : IRequestHandler<ArchiveFormCommand, Form?>
{
    private readonly ApplicationDbContext _context;

    public ArchiveFormCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Form?> Handle(ArchiveFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Forms.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (form is null)
            return null;

        form.IsInArchive = true;

        _context.Update(form);
        await _context.SaveChangesAsync(cancellationToken);

        return form;
    }
}