using DomraSinForms.Application.Interfaces;
using DomraSinForms.Domain.Models;
using MediatR;

namespace DomraSinForms.Application.Forms.Queries.Get;

public record class GetFormQuery (string Id, string UserId) : IRequest<Option<Form>>
{
    
}
