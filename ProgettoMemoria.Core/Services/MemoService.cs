using GymGo.Gateway.Models.Memo;
using GymGo.Gateway.Repositories;

namespace GymGo.Core.Services;

public interface IMemoService
{
    Task Save(PostMemoRequest memo);
    Task<List<Memo>> GetAll();
    Task<Memo> GetById(string id);
    Task<List<Memo>> GetByUserDay(string Id, int dayOfWeek);
}

public class MemoService : IMemoService
{
    public  IMemoRepository _repository { get; set;  }

    public MemoService(IMemoRepository repository)
    {
        _repository = repository;
    }
    public Task Save(PostMemoRequest memo) => _repository.Save(memo);

    public async Task<List<Memo>> GetAll() => await _repository.GetAll();

    public async Task<Memo> GetById(string id) => await _repository.GetById(id);

    public async Task<List<Memo>> GetByUserDay(string Id, int dayOfWeek) => await _repository.GetByUserDay(Id, dayOfWeek);
}
