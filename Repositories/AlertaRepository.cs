using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.Models;
using SentinelEye.Repositories.Interfaces;

namespace SentinelEye.Repositories;

public class AlertaRepository : IAlertaRepository
{
    private readonly AppDbContext _context;

    public AlertaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Alerta>> GetAllAsync()
    {
        return await _context.Alertas.ToListAsync();
    }

    public async Task<Alerta?> GetByIdAsync(long id)
    {
        return await _context.Alertas.FindAsync(id);
    }

    public async Task<Alerta> CreateAsync(Alerta alerta)
    {
        _context.Alertas.Add(alerta);

        await _context.SaveChangesAsync();

        return alerta;
    }

    public async Task<bool> UpdateAsync(long id, Alerta alerta)
    {
        var alertaExistente = await _context.Alertas.FindAsync(id);

        if (alertaExistente == null)
        {
            return false;
        }

        alertaExistente.Tipo = alerta.Tipo;
        alertaExistente.Descricao = alerta.Descricao;
        alertaExistente.NivelRisco = alerta.NivelRisco;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var alerta = await _context.Alertas.FindAsync(id);

        if (alerta == null)
        {
            return false;
        }

        _context.Alertas.Remove(alerta);

        await _context.SaveChangesAsync();

        return true;
    }
}