using Vote.Data.Entities;
using Vote.Data.Infrastructure.Abstraction;
using VoteApp.Service.Models;
using VoteApp.Service.Services.Abstraction;

namespace VoteApp.Service.Services.Realization;

public class AnswerService : IAnswerService
{
    private readonly IRepository<Answer> _answerRepository;
    private readonly IRepository<UserAnswer> _userAnswerRepository;

    public AnswerService(
        IRepository<Answer> answerRepository,
        IRepository<UserAnswer> userAnswerRepository
    )
    {
        _answerRepository = answerRepository;
        _userAnswerRepository = userAnswerRepository;
    }

    public IEnumerable<Answer> GetAnswersByQuestionId(Guid questionId) =>
        _answerRepository
            .GetAll()
            .Where(a => a.QuestionId == questionId);

    public Answer Add(AddAnswerModel addAnswerModel) =>
        _answerRepository
            .Add(new Answer
            {
                QuestionId = addAnswerModel.QuestionId,
                Text = addAnswerModel.Text
            });

    public Answer? GetById(Guid id) => _answerRepository.GetById(id);

    public IEnumerable<Guid> GetVoterIdsByAnswerId(Guid answerId) =>
        _userAnswerRepository
            .GetAll()
            .Where(ua => ua.AnswerId == answerId)
            .Select(ua => ua.UserId);

    public void AddUserAnswer(Guid userId, Guid answerId) =>
        _userAnswerRepository
            .Add(
                new UserAnswer
                {
                    UserId = userId,
                    AnswerId = answerId
                }
            );
}