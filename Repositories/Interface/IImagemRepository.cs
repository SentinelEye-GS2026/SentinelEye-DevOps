using SentinelEye.Models;

namespace SentinelEye.Repositories.Interfaces;

public interface IImagemSateliteRepository
{
    Task<IEnumerable<ImagemSatelite>> GetAllAsync();

    Task<ImagemSatelite?> GetByIdAsync(long id);

    Task<ImagemSatelite> CreateAsync(ImagemSatelite imagem);

    Task<bool> DeleteAsync(long id);

    Task<bool> UpdateAsync(long id, ImagemSatelite imagem);
}