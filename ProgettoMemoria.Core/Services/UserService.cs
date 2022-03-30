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

    public async Task<User> GetById(string id) => await _repository.GetById(id);

    public async Task Save(PostUserRequest user) => await _repository.Save(user);
}
