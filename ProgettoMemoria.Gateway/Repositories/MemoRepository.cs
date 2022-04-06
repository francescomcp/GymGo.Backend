using MongoDB.Driver;
using GymGo.Gateway.Infrastructure;
using GymGo.Gateway.Models.Memo;

namespace GymGo.Gateway.Repositories;

public interface IMemoRepository
{
    Task Save(PostMemoRequest memo);
    Task<List<Memo>> GetAll();
    Task<Memo> GetById(string id);
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
        if (memo.DayOfWeek > 0 && memo.DayOfWeek < 8)
        {
            if (memo.Id == null)
            {
                await collection.InsertOneAsync(memo);
            }
            else
            {
                await collection.ReplaceOneAsync(x => x.Id == memo.Id, memo);
            }
        }
    }

    public async Task<List<Memo>> GetAll()
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<Memo>("Memo");
        return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<Memo> GetById(string id)
    {
        var collection = _connection.GetReadyConnectionAsync().GetCollection<Memo>("Memo");
        return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}
