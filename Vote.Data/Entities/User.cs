namespace Vote.Data.Entities;

public class User : BaseEntity, IEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FullName => $"{FirstName} {LastName}";

    public DateTime BirthDate { get; set; }

    public int Age => (int) ((DateTime.Now - BirthDate).TotalDays / 365.2425);
}