using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;

namespace SentinelEye.Repositories;

public class ImagemSateliteRepository : IImagemSateliteRepository
{
    private readonly AppDbContext _context;

    public ImagemSateliteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ImagemSatelite>> GetAllAsync()
    {
        return await _context.ImagensSatelite.ToListAsync();
    }

    public async Task<ImagemSatelite?> GetByIdAsync(long id)
    {
        return await _context.ImagensSatelite.FindAsync(id);
    }

    public async Task<ImagemSatelite> CreateAsync(ImagemSatelite imagem)
    {
        _context.ImagensSatelite.Add(imagem);

        await _context.SaveChangesAsync();

        return imagem;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var imagem = await _context.ImagensSatelite.FindAsync(id);

        if (imagem == null)
        {
            return false;
        }

        _context.ImagensSatelite.Remove(imagem);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(long id, ImagemSatelite imagem)
    {
        var imagemExistente = await _context.ImagensSatelite.FindAsync(id);

        if (imagemExistente == null)
        {
            return false;
        }

        imagemExistente.UrlImagem = imagem.UrlImagem;
        imagemExistente.DataCaptura = imagem.DataCaptura;
        imagemExistente.Fonte = imagem.Fonte;
        imagemExistente.OcorrenciaId = imagem.OcorrenciaId;

        await _context.SaveChangesAsync();

        return true;
    
    }
}