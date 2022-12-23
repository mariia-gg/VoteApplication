using Vote.Data.Entities;
using VoteApp.Service.Models;

namespace VoteApp.Service.Services.Abstraction;

public interface IUserService
{
    public User? GetById(Guid id);

    public User Add(AddUserModel addUserModel);

    public User? GetByUserName(string userName);

    public IEnumerable<User> GetUsersByIds(IEnumerable<Guid> ids);
}