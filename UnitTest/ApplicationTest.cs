using AutoFixture;
using Moq;
using Vote.Data.Entities;
using Vote.Data.Infrastructure.Abstraction;
using VoteApp.Service.Services.Realization;

namespace UnitTest;

public class ApplicationTest
{
    [Fact]
    public void Test1()
    {
        var repositoryMock = new Mock<IRepository<User>>();

        var users = new Fixture().Create<IEnumerable<User>>();

        repositoryMock.Setup(repository => repository.GetAll()).Returns(users);

        var userService = new UserService(repositoryMock.Object);

        Assert.Equal(userService.GetUsersByIds(users.Select(u => u.Id)), users);
    }

    [Fact]
    public void Test2()
    {
        var repositoryMock = new Mock<IRepository<Question>>();

        var questions = new Fixture().Create<IEnumerable<Question>>();

        repositoryMock.Setup(repository => repository.GetAll()).Returns(questions);

        var questionService = new QuestionService(repositoryMock.Object);

        Assert.Equal(questionService.GetAll(), questions);
    }
}