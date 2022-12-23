namespace VoteApp.Service.Models;

public class AddUserModel
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }
}