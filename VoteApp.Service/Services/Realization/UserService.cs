using Vote.Data.Entities;
using Vote.Data.Infrastructure.Abstraction;
using VoteApp.Service.Models;
using VoteApp.Service.Services.Abstraction;

namespace VoteApp.Service.Services.Realization;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository) => _userRepository = userRepository;

    public User? GetById(Guid id) => _userRepository.GetById(id);

    public User Add(AddUserModel addUserModel)
    {
        var user = new User
        {
            BirthDate = addUserModel.BirthDate,
            FirstName = addUserModel.FirstName,
            LastName = addUserModel.LastName
        };

        return _userRepository.Add(user);
    }

    public User? GetByUserName(string userName) =>
        _userRepository
            .GetAll()
            .FirstOrDefault(u => u.FullName == userName || u.LastName == userName);

    public IEnumerable<User> GetUsersByIds(IEnumerable<Guid> ids) =>
        _userRepository
            .GetAll()
            .Where(u => ids.Contains(u.Id));
}