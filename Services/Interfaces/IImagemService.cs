using SentinelEye.Models;

namespace SentinelEye.Services.Interfaces;

public interface IImagemSateliteService
{
    Task<IEnumerable<ImagemSatelite>> GetAllAsync();

    Task<ImagemSatelite?> GetByIdAsync(long id);

    Task<ImagemSatelite> CreateAsync(ImagemSatelite imagem);

    Task<bool> UpdateAsync(long id, ImagemSatelite imagem);

    Task<bool> DeleteAsync(long id);
}