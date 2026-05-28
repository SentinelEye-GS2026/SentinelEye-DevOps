using SentinelEye.Models;

namespace SentinelEye.Repositories.Interfaces;

public interface IAgenteRepository
{
    Task<IEnumerable<Agente>> GetAllAsync();

    Task<Agente?> GetByIdAsync(long id);

    Task<Agente> CreateAsync(Agente agente);

    Task<bool> UpdateAsync(long id, Agente agente);

    Task<bool> DeleteAsync(long id);
}