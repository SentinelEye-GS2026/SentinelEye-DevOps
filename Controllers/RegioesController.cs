using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.DTOs.RegiaoDTO;
using SentinelEye.Models;

namespace SentinelEye.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegioesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RegioesController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Lista todas as regiões cadastradas.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeituraRegiaoDto>>> Get()
    {
        var regioes = await _context.Regioes
            .Select(r => new LeituraRegiaoDto
            {
                Id = r.Id,
                Nome = r.Nome,
                Pais = r.Pais,
                NivelRisco = r.NivelRisco
            })
            .ToListAsync();

        return Ok(regioes);
    }

    /// <summary>
    /// Busca uma região pelo ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeituraRegiaoDto>> GetById(int id)
    {
        var regiao = await _context.Regioes.FindAsync(id);

        if (regiao == null)
            return NotFound();

        return Ok(new LeituraRegiaoDto
        {
            Id = regiao.Id,
            Nome = regiao.Nome,
            Pais = regiao.Pais,
            NivelRisco = regiao.NivelRisco
        });
    }

    /// <summary>
    /// Cadastra uma nova região.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post(CriacaoRegiaoDto dto)
    {
        var regiao = new Regiao
        {
            Nome = dto.Nome,
            Pais = dto.Pais,
            NivelRisco = dto.NivelRisco
        };

        _context.Regioes.Add(regiao);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = regiao.Id }, regiao);
    }

    /// <summary>
    /// Atualiza uma região existente.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, AtualizacaoRegiaoDto dto)
    {
        var regiao = await _context.Regioes.FindAsync(id);

        if (regiao == null)
            return NotFound();

        regiao.Nome = dto.Nome;
        regiao.Pais = dto.Pais;
        regiao.NivelRisco = dto.NivelRisco;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Remove uma região.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var regiao = await _context.Regioes.FindAsync(id);

        if (regiao == null)
            return NotFound();

        _context.Regioes.Remove(regiao);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}