using ProgettoPromemoria.Gateway.Models.Memo;
using ProgettoPromemoria.Gateway.Repositories;

namespace ProgettoPromemoria.Core.Services;

public interface IMemoService
{
    Task Save(PostMemoRequest memo);
}

public class MemoService : IMemoService
{
    public  IMemoRepository _repository { get; set;  }

    public MemoService(IMemoRepository repository)
    {
        _repository = repository;
    }
    public Task Save(PostMemoRequest memo) => _repository.Save(memo);
}
