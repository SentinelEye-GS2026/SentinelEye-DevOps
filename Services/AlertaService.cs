using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;
using SentinelEye.Services.Interfaces;

namespace SentinelEye.Services;

public class AlertaService : IAlertaService
{
    private readonly IAlertaRepository _repository;

    public AlertaService(IAlertaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Alerta>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Alerta?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Alerta> CreateAsync(Alerta alerta)
    {
        return await _repository.CreateAsync(alerta);
    }

    public async Task<bool> UpdateAsync(long id, Alerta alerta)
    {
        return await _repository.UpdateAsync(id, alerta);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
}