using MediatR;

namespace DomraSinForms.Application.Interfaces;

public interface IDeleteRequest : IRequest<bool>
{
    public string Id { get; set; }
}