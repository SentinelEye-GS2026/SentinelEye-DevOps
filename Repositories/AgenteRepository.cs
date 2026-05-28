using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;

namespace SentinelEye.Repositories;

public class AgenteRepository : IAgenteRepository
{
    private readonly AppDbContext _context;

    public AgenteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Agente>> GetAllAsync()
    {
        return await _context.Agentes.ToListAsync();
    }

    public async Task<Agente?> GetByIdAsync(long id)
    {
        return await _context.Agentes.FindAsync(id);
    }

    public async Task<Agente> CreateAsync(Agente agente)
    {
        _context.Agentes.Add(agente);

        await _context.SaveChangesAsync();

        return agente;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var agente = await _context.Agentes.FindAsync(id);

        if (agente == null)
        {
            return false;
        }

        _context.Agentes.Remove(agente);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(long id, Agente agente)
    {
        var existingAgente = await _context.Agentes.FindAsync(id);

        if (existingAgente == null)
        {
            return false;
        }

        _context.Entry(existingAgente).CurrentValues.SetValues(agente);

        await _context.SaveChangesAsync();

        return true;
    }
}