using ProgettoPromemoria.Gateway.Infrastructure;
using ProgettoPromemoria.Gateway.Models.Memo;

namespace ProgettoPromemoria.Gateway.Repositories;

public interface IMemoRepository
{
    Task Save(PostMemoRequest memo);
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
}
