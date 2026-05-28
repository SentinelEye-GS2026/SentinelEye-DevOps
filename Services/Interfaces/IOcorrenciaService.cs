using SentinelEye.Models;

namespace SentinelEye.Services.Interfaces;

public interface IOcorrenciaService
{
    Task<IEnumerable<Ocorrencia>> GetAllAsync();

    Task<Ocorrencia?> GetByIdAsync(long id);

    Task<Ocorrencia> CreateAsync(Ocorrencia ocorrencia);

    Task<bool> UpdateAsync(long id, Ocorrencia ocorrencia);

    Task<bool> DeleteAsync(long id);
}