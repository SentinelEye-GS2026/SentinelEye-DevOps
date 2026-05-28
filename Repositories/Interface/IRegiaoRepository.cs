using SentinelEye.Models;

namespace SentinelEye.Repositories.Interfaces;

public interface IRegiaoRepository
{
    Task<IEnumerable<Regiao>> GetAllAsync();

    Task<Regiao?> GetByIdAsync(long id);

    Task<Regiao> CreateAsync(Regiao regiao);

    Task<bool> UpdateAsync(long id, Regiao regiao);

    Task<bool> DeleteAsync(long id);
}