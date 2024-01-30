using DomraSin.Domain.Interfaces.Repositories;
using DomraSin.Domain.Models;

namespace DomraSin.Persistence.Repositories
{
    public class AnswerRepository : IAnswersRepository
    {
        public IQueryable<Answer> GetCollection(string formAnswersId)
        {
            throw new NotImplementedException();
        }
    }
}
