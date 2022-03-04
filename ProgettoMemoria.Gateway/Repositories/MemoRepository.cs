using MongoDB.Driver;
using ProgettoPromemoria.Gateway.Infrastructure;
using ProgettoPromemoria.Gateway.Models.Memo;

namespace ProgettoPromemoria.Gateway.Repositories;

public interface IMemoRepository
{
    Task Save(PostMemoRequest memo);
    Task<List<Memo>> GetAll();
}

public class MemoRepository : IMemoRepository
{
    public IConnectionFactory _connection;

    public MemoRepository(IConnectionFactory connection)
    {
        _connection = connection;
    }

    public async Task Save(PostMemoRequest memo)
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<PostMemoRequest>("Memo");
        await collection.InsertOneAsync(memo);
    }

    public async Task<List<Memo>> GetAll()
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<Memo>("Memo");
        return await collection.Find(_ => true).ToListAsync();
    }
}
