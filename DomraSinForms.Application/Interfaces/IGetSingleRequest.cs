using MediatR;

namespace DomraSinForms.Application.Interfaces;

public interface IGetSingleRequest<TEntity> : IRequest<TEntity>
{
    public string Id { get; set; }
}