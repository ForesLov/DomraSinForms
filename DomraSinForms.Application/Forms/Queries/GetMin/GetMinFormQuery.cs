using DomraSinForms.Domain.Models;
using MediatR;

namespace DomraSinForms.Application.Forms.Queries.GetMin;

public class GetMinFormQuery : IRequest<Option<Form>>
{
    public string Id { get; set; }
}