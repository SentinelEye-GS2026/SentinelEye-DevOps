using SentinelEye.Models;

namespace SentinelEye.Services.Interfaces;

public interface IAlertaService
{
    Task<IEnumerable<Alerta>> GetAllAsync();

    Task<Alerta?> GetByIdAsync(long id);

    Task<Alerta> CreateAsync(Alerta alerta);

    Task<bool> UpdateAsync(long id, Alerta alerta);

    Task<bool> DeleteAsync(long id);
}