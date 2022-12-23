namespace VoteApp.Service.Models;

public class AddAnswerModel
{
    public string Text { get; set; } = null!;

    public Guid QuestionId { get; set; }
}