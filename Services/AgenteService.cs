using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;
using SentinelEye.Services.Interfaces;

namespace SentinelEye.Services;

public class AgenteService : IAgenteService
{
    private readonly IAgenteRepository _repository;

    public AgenteService(IAgenteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Agente>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Agente?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Agente> CreateAsync(Agente agente)
    {
        return await _repository.CreateAsync(agente);
    }

    public async Task<bool> UpdateAsync(long id, Agente agente)
    {
        return await _repository.UpdateAsync(id, agente);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
}