using SentinelEye.Models;

namespace SentinelEye.Services.Interfaces;

public interface IAgenteService
{
    Task<IEnumerable<Agente>> GetAllAsync();

    Task<Agente?> GetByIdAsync(long id);

    Task<Agente> CreateAsync(Agente agente);

    Task<bool> UpdateAsync(long id, Agente agente);

    Task<bool> DeleteAsync(long id);
}