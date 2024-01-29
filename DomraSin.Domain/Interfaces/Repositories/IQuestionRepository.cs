using DomraSin.Domain.Models.FormItems;
namespace DomraSin.Domain.Interfaces.Repositories;

public interface IQuestionRepository
{
    Task<Question> Get(string id, CancellationToken cancellationToken);
    IQueryable<Question> GetCollection(string questionId);
    Task<bool> Insert(Question question, CancellationToken cancellationToken);
    Task<bool> Delete(string questionId, CancellationToken cancellationToken);
}
