using Vote.Data.Entities;
using Vote.Data.Infrastructure.Abstraction;
using VoteApp.Service.Models;
using VoteApp.Service.Services.Abstraction;

namespace VoteApp.Service.Services.Realization;

public class QuestionService : IQuestionService
{
    private readonly IRepository<Question> _questionRepository;

    public QuestionService(IRepository<Question> questionRepository) => _questionRepository = questionRepository;

    public Question? GetById(Guid id) => _questionRepository.GetById(id);

    public Question Add(AddQuestionModel addQuestionModel) => _questionRepository.Add(new Question
    {
        Text = addQuestionModel.Text
    });

    public IEnumerable<Question> GetAll() => _questionRepository.GetAll();
}