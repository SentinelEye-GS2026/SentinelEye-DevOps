using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;

namespace SentinelEye.Repositories;

public class RegiaoRepository : IRegiaoRepository
{
    private readonly AppDbContext _context;

    public RegiaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Regiao>> GetAllAsync()
    {
        return await _context.Regioes.ToListAsync();
    }

    public async Task<Regiao?> GetByIdAsync(long id)
    {
        return await _context.Regioes.FindAsync(id);
    }

    public async Task<Regiao> CreateAsync(Regiao regiao)
    {
        _context.Regioes.Add(regiao);

        await _context.SaveChangesAsync();

        return regiao;
    }

    public async Task<bool> UpdateAsync(long id, Regiao regiao)
    {
        var regiaoExistente = await _context.Regioes.FindAsync(id);

        if (regiaoExistente == null)
        {
            return false;
        }

        regiaoExistente.Nome = regiao.Nome;
        regiaoExistente.Pais = regiao.Pais;
        regiaoExistente.NivelRisco = regiao.NivelRisco;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var regiao = await _context.Regioes.FindAsync(id);

        if (regiao == null)
        {
            return false;
        }

        _context.Regioes.Remove(regiao);

        await _context.SaveChangesAsync();

        return true;
    }
}