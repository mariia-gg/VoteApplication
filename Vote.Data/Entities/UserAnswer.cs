namespace Vote.Data.Entities;

public class UserAnswer : BaseEntity, IEntity
{
    public Guid UserId { get; set; }

    public Guid AnswerId { get; set; }
}