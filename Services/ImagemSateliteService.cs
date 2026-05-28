using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;
using SentinelEye.Services.Interfaces;

namespace SentinelEye.Services;

public class ImagemSateliteService : IImagemSateliteService
{
    private readonly IImagemSateliteRepository _repository;

    public ImagemSateliteService(IImagemSateliteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ImagemSatelite>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ImagemSatelite?> GetByIdAsync(long id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<ImagemSatelite> CreateAsync(ImagemSatelite imagem)
    {
        return await _repository.CreateAsync(imagem);
    }

    public async Task<bool> UpdateAsync(long id, ImagemSatelite imagem)
    {
        return await _repository.UpdateAsync(id, imagem);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }
}