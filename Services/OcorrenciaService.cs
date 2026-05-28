using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;
using SentinelEye.Services.Interfaces;

namespace SentinelEye.Services;

public class OcorrenciaService : IOcorrenciaService
{
    private readonly IOcorrenciaRepository _repository;

    public OcorrenciaService(IOcorrenciaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Ocorrencia>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Ocorrencia?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Ocorrencia> CreateAsync(Ocorrencia ocorrencia)
    {
        return await _repository.CreateAsync(ocorrencia);
    }

    public async Task<bool> UpdateAsync(long id, Ocorrencia ocorrencia)
    {
        return await _repository.UpdateAsync(id, ocorrencia);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
}