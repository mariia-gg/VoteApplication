namespace Vote.Data.Entities;

public class Answer : BaseEntity, IEntity
{
    public string Text { get; set; } = null!;

    public IEnumerable<User> Voters { get; set; } = new List<User>();

    public Guid QuestionId { get; set; }
}