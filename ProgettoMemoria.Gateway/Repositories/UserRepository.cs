using MongoDB.Driver;
using GymGo.Gateway.Infrastructure;
using GymGo.Gateway.Models.User;

namespace GymGo.Gateway.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task Save(PostUserRequest user);
    Task<User> GetById(string id);
    Task<User> Authenticate(string username, string password);
}
public class UserRepository : IUserRepository
{
    public IConnectionFactory _connection;

    public UserRepository(IConnectionFactory connection)
    {
        _connection = connection;
    }

    public async Task<User> Authenticate(string username, string password)
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<User>("Users");
       return await collection.Find(u => u.UserName == username && u.Password == password).FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetAll()
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<User>("Users");
        return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<User> GetById(string id)
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<User>("Users");
        return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task Save(PostUserRequest user)
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<PostUserRequest>("Users");
        await collection.InsertOneAsync(user);
    }
}
