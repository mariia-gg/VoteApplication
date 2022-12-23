namespace Vote.Data.Entities;

public class Question : BaseEntity, IEntity
{
    public string Text { get; set; } = null!;

    public IEnumerable<Answer> Answers { get; set; } = new List<Answer>();
}