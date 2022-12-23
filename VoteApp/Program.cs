using Vote.Data.Entities;
using Vote.Data.Infrastructure.Realization;
using VoteApp;
using VoteApp.Service.Services.Realization;

new Application(
        new QuestionService(
            new Repository<Question>()
        ),
        new AnswerService(
            new Repository<Answer>(),
            new Repository<UserAnswer>()
        ),
        new UserService(
            new Repository<User>()
        )
    )
    .Run();