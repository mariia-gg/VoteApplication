using Vote.Data.Entities;
using VoteApp.Service.Models;

namespace VoteApp.Service.Services.Abstraction;

public interface IQuestionService
{
    public Question? GetById(Guid id);

    public Question Add(AddQuestionModel addQuestionModel);

    public IEnumerable<Question> GetAll();
}