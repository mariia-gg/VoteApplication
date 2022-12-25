using VoteApp.Service.Models;
using VoteApp.Service.Services.Abstraction;

namespace VoteApp;

internal class Application
{
    private readonly IQuestionService _questionService;
    private readonly IAnswerService _answerService;
    private readonly IUserService _userService;

    public Application(
        IQuestionService questionService,
        IAnswerService answerService,
        IUserService userService
    )
    {
        _questionService = questionService;
        _answerService = answerService;
        _userService = userService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Hello, welcome to the vote application enter command (help or exit)");
            HandleCommand(Console.ReadLine());
        }
    }

    private void HandleCommand(string? command)
    {
       
        command = command?.ToLower();

        if (command == "exit")
        {
            Environment.Exit(0);
        }

        if (command == "help")
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("exit - exit from application");
            Console.WriteLine("help - show this message");
            Console.WriteLine("add question - add question");
            Console.WriteLine("add answer - add answer");
            Console.WriteLine("add user - add user");
            Console.WriteLine("show questions - show all questions");
            Console.WriteLine("show answers - show all answers");
            Console.WriteLine("vote - vote for answer");
            Console.WriteLine("show results - show results");
        }

        if (command == "add question")
        {
            Console.WriteLine("Enter question text:");
            var questionText = Console.ReadLine();

            if (questionText == null)
            {
                Console.WriteLine("Question text is empty");

                return;
            }

            _questionService.Add(new AddQuestionModel
            {
                Text = questionText
            });

            Console.WriteLine("Question added");
        }

        if (command == "add answer")
        {
            Console.WriteLine("Enter answer text:");
            var answerText = Console.ReadLine();

            if (answerText == null)
            {
                Console.WriteLine("Answer text is empty");

                return;
            }

            Console.WriteLine("Enter question id:");
            var questionId = Console.ReadLine();

            if (questionId == null)
            {
                Console.WriteLine("Question id is empty");

                return;
            }

            _answerService.Add(new AddAnswerModel
            {
                Text = answerText,
                QuestionId = Guid.Parse(questionId)
            });

            Console.WriteLine("Answer added");
        }

        if (command == "add user")
        {
            Console.WriteLine("Enter user name:");
            var userName = Console.ReadLine();

            if (userName == null)
            {
                Console.WriteLine("User name is empty");

                return;
            }

            _userService.Add(new AddUserModel
            {
                FirstName = userName.Split(' ')[0],
                LastName = userName.Split(' ')[1]
            });

            Console.WriteLine("User added");
        }

        if (command == "show questions")
        {
            var questions = _questionService.GetAll();

            foreach (var question in questions)
            {
                Console.WriteLine($"Question id: {question.Id}");
                Console.WriteLine($"Question text: {question.Text}");
                Console.WriteLine();
            }
        }

        if (command == "show answers")
        {
            Console.WriteLine("Enter question id:");
            var questionId = Console.ReadLine();

            if (questionId == null)
            {
                Console.WriteLine("Question id is empty");

                return;
            }

            var answers = _answerService.GetAnswersByQuestionId(Guid.Parse(questionId));

            foreach (var answer in answers)
            {
                Console.WriteLine($"Answer id: {answer.Id}");
                Console.WriteLine($"Answer text: {answer.Text}");
                Console.WriteLine($"Question id: {answer.QuestionId}");
                Console.WriteLine();
            }
        }

        if (command == "vote")
        {
            Console.WriteLine("Enter user id:");
            var userId = Console.ReadLine();

            if (userId == null)
            {
                Console.WriteLine("User id is empty");

                return;
            }

            Console.WriteLine("Enter answer id:");
            var answerId = Console.ReadLine();

            if (answerId == null)
            {
                Console.WriteLine("Answer id is empty");

                return;
            }

            _answerService.AddUserAnswer(Guid.Parse(userId), Guid.Parse(answerId));

            Console.WriteLine("Vote added");
        }

        if (command == "show results")
        {
            Console.WriteLine("Enter question id:");
            var questionId = Console.ReadLine();

            if (questionId == null)
            {
                Console.WriteLine("Question id is empty");

                return;
            }

            var answers = _answerService.GetAnswersByQuestionId(Guid.Parse(questionId));

            foreach (var answer in answers)
            {
                Console.WriteLine($"Answer id: {answer.Id}");
                Console.WriteLine($"Answer text: {answer.Text}");
                Console.WriteLine($"Question id: {answer.QuestionId}");

                var voters = _userService.GetUsersByIds(_answerService.GetVoterIdsByAnswerId(answer.Id)).ToList();

                Console.WriteLine($"Voters count: {voters.Count}");

                foreach (var voter in voters)
                {
                    Console.WriteLine($"Voter id: {voter.Id}");
                    Console.WriteLine($"Voter name: {voter.FullName}");
                }

                Console.WriteLine();
            }
        }
    }
}