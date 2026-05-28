using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.DTOs.AgenteDTO;
using SentinelEye.Models;

namespace SentinelEye.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgentesController : ControllerBase
{
    private readonly AppDbContext _context;

    public AgentesController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Lista todos os agentes.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeituraAgenteDto>>> Get()
    {
        var agentes = await _context.Agentes
            .Include(a => a.Regiao)
            .Select(a => new LeituraAgenteDto
            {
                Id = a.Id,
                Nome = a.Nome,
                Email = a.Email,
                Cargo = a.Cargo,
                Regiao = a.Regiao.Nome
            })
            .ToListAsync();

        return Ok(agentes);
    }

    /// <summary>
    /// Busca um agente pelo ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeituraAgenteDto>> GetById(int id)
    {
        var agente = await _context.Agentes
            .Include(a => a.Regiao)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (agente == null)
            return NotFound();

        return Ok(new LeituraAgenteDto
        {
            Id = agente.Id,
            Nome = agente.Nome,
            Email = agente.Email,
            Cargo = agente.Cargo,
            Regiao = agente.Regiao.Nome
        });
    }

    /// <summary>
    /// Lista agentes por região.
    /// </summary>
    [HttpGet("regiao/{regiaoId}")]
    public async Task<ActionResult<IEnumerable<LeituraAgenteDto>>> GetPorRegiao(int regiaoId)
    {
        var agentes = await _context.Agentes
            .Include(a => a.Regiao)
            .Where(a => a.RegiaoId == regiaoId)
            .Select(a => new LeituraAgenteDto
            {
                Id = a.Id,
                Nome = a.Nome,
                Email = a.Email,
                Cargo = a.Cargo,
                Regiao = a.Regiao.Nome
            })
            .ToListAsync();

        return Ok(agentes);
    }

    /// <summary>
    /// Cadastra um novo agente.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post(CriacaoAgenteDto dto)
    {
        var regiaoExiste = await _context.Regioes
            .AnyAsync(r => r.Id == dto.RegiaoId);

        if (!regiaoExiste)
            return BadRequest("Região não encontrada.");

        var agente = new Agente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Cargo = dto.Cargo,
            RegiaoId = dto.RegiaoId
        };

        _context.Agentes.Add(agente);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = agente.Id }, agente);
    }

    /// <summary>
    /// Atualiza um agente.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, AtualizacaoAgenteDto dto)
    {
        var agente = await _context.Agentes.FindAsync(id);

        if (agente == null)
            return NotFound();

        agente.Nome = dto.Nome;
        agente.Email = dto.Email;
        agente.Cargo = dto.Cargo;
        agente.RegiaoId = dto.RegiaoId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Remove um agente.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var agente = await _context.Agentes.FindAsync(id);

        if (agente == null)
            return NotFound();

        _context.Agentes.Remove(agente);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}