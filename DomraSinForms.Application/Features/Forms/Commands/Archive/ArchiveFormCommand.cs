using DomraSinForms.Domain.Models;
using MediatR;

namespace DomraSinForms.Application.Features.Forms.Commands.Archive;

public class ArchiveFormCommand : IRequest<Form?>
{
    /// <summary>
    /// Id of form to archive.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}