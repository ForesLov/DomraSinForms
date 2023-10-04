using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Versions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Features.Forms.Commands.Delete;

public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, bool>
{
    private readonly IDatabaseContext _context;

    public DeleteFormCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _context.Set<Form>().FirstOrDefaultAsync(f => f.Id == request.Id && f.CreatorId == request.UserId, cancellationToken);
        if (form == null)
            return false;

        var versions = await _context.Set<FormVersion>().Where(fv => fv.FormId == form.Id).ToArrayAsync(cancellationToken);

        _context.Set<FormVersion>().RemoveRange(versions);
        _context.Set<Form>().Remove(form);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}