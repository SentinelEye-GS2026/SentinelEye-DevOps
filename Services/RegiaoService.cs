using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;
using SentinelEye.Services.Interfaces;

namespace SentinelEye.Services;

public class RegiaoService : IRegiaoService
{
    private readonly IRegiaoRepository _repository;

    public RegiaoService(IRegiaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Regiao>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Regiao?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Regiao> CreateAsync(Regiao regiao)
    {
        return await _repository.CreateAsync(regiao);
    }

    public async Task<bool> UpdateAsync(long id, Regiao regiao)
    {
        return await _repository.UpdateAsync(id, regiao);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
}