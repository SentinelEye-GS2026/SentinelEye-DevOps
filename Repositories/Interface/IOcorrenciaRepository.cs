using SentinelEye.Models;

namespace SentinelEye.Repositories.Interfaces;

public interface IOcorrenciaRepository
{
    Task<IEnumerable<Ocorrencia>> GetAllAsync();

    Task<Ocorrencia?> GetByIdAsync(long id);

    Task<Ocorrencia> CreateAsync(Ocorrencia ocorrencia);

    Task<bool> UpdateAsync(long id, Ocorrencia ocorrencia);

    Task<bool> DeleteAsync(long id);
}