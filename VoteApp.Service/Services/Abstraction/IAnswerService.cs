using Vote.Data.Entities;
using VoteApp.Service.Models;

namespace VoteApp.Service.Services.Abstraction;

public interface IAnswerService
{
    public IEnumerable<Answer> GetAnswersByQuestionId(Guid questionId);

    public Answer Add(AddAnswerModel addAnswerModel);

    public Answer? GetById(Guid id);

    public IEnumerable<Guid> GetVoterIdsByAnswerId(Guid answerId);

    public void AddUserAnswer(Guid userId, Guid answerId);
}