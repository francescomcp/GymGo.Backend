using ProgettoPromemoria.Gateway.Models.User;
using ProgettoPromemoria.Gateway.Repositories;

namespace ProgettoPromemoria.Core.Services;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task Save(PostUserRequest user);
    Task<User> GetById(string id);
}
public class UserService : IUserService
{
    public IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    public Task<List<User>> GetAll() => _repository.GetAll();

    public Task<User> GetById(string id) => _repository.GetById(id);

    public Task Save(PostUserRequest user) => _repository.Save(user);
}
