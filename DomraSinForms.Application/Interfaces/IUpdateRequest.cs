using MediatR;

namespace DomraSinForms.Application.Interfaces;

public interface IUpdateRequest<TEntity> : IRequest<TEntity>
{
    public string Id { get; set; }
}