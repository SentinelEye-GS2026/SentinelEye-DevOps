using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;

namespace SentinelEye.Repositories;

public class OcorrenciaRepository : IOcorrenciaRepository
{
    private readonly AppDbContext _context;

    public OcorrenciaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ocorrencia>> GetAllAsync()
    {
        return await _context.Ocorrencias.ToListAsync();
    }

    public async Task<Ocorrencia?> GetByIdAsync(long id)
    {
        return await _context.Ocorrencias.FindAsync(id);
    }

    public async Task<Ocorrencia> CreateAsync(Ocorrencia ocorrencia)
    {
        _context.Ocorrencias.Add(ocorrencia);

        await _context.SaveChangesAsync();

        return ocorrencia;
    }

    public async Task<bool> UpdateAsync(long id, Ocorrencia ocorrencia)
    {
        var ocorrenciaExistente = await _context.Ocorrencias.FindAsync(id);

        if (ocorrenciaExistente == null)
        {
            return false;
        }

        ocorrenciaExistente.Tipo = ocorrencia.Tipo;
        ocorrenciaExistente.Descricao = ocorrencia.Descricao;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var ocorrencia = await _context.Ocorrencias.FindAsync(id);

        if (ocorrencia == null)
        {
            return false;
        }

        _context.Ocorrencias.Remove(ocorrencia);

        await _context.SaveChangesAsync();

        return true;
    }
}