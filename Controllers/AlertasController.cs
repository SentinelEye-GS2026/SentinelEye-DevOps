using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.DTOs.AlertaDTO;
using SentinelEye.Models;

namespace SentinelEye.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertasController : ControllerBase
{
    private readonly AppDbContext _context;

    public AlertasController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Lista todos os alertas.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeituraAlertaDto>>> Get()
    {
        var alertas = await _context.Alertas
            .Include(a => a.Ocorrencia)
            .Select(a => new LeituraAlertaDto
            {
                Id = a.Id,
                Tipo = a.Tipo,
                NivelRisco = a.NivelRisco,
                Descricao = a.Descricao,
                DataEmissao = a.DataEmissao,
                Ocorrencia = a.Ocorrencia.Tipo
            })
            .ToListAsync();

        return Ok(alertas);
    }

    /// <summary>
    /// Busca um alerta pelo ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeituraAlertaDto>> GetById(int id)
    {
        var alerta = await _context.Alertas
            .Include(a => a.Ocorrencia)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (alerta == null)
            return NotFound();

        return Ok(new LeituraAlertaDto
        {
            Id = alerta.Id,
            Tipo = alerta.Tipo,
            NivelRisco = alerta.NivelRisco,
            Descricao = alerta.Descricao,
            DataEmissao = alerta.DataEmissao,
            Ocorrencia = alerta.Ocorrencia.Tipo
        });
    }

    /// <summary>
    /// Lista alertas por nível de risco.
    /// </summary>
    [HttpGet("risco/{nivel}")]
    public async Task<ActionResult<IEnumerable<LeituraAlertaDto>>> GetPorRisco(string nivel)
    {
        var alertas = await _context.Alertas
            .Include(a => a.Ocorrencia)
            .Where(a => a.NivelRisco == nivel)
            .Select(a => new LeituraAlertaDto
            {
                Id = a.Id,
                Tipo = a.Tipo,
                NivelRisco = a.NivelRisco,
                Descricao = a.Descricao,
                DataEmissao = a.DataEmissao,
                Ocorrencia = a.Ocorrencia.Tipo
            })
            .ToListAsync();

        return Ok(alertas);
    }

    /// <summary>
    /// Cadastra um novo alerta.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post(CriacaoAlertaDto dto)
    {
        var ocorrenciaExiste = await _context.Ocorrencias
            .AnyAsync(o => o.Id == dto.OcorrenciaId);

        if (!ocorrenciaExiste)
            return BadRequest("Ocorrência não encontrada.");

        var alerta = new Alerta
        {
            Tipo = dto.Tipo,
            NivelRisco = dto.NivelRisco,
            Descricao = dto.Descricao,
            DataEmissao = dto.DataEmissao,
            OcorrenciaId = dto.OcorrenciaId
        };

        _context.Alertas.Add(alerta);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = alerta.Id }, alerta);
    }

    /// <summary>
    /// Atualiza um alerta.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, AtualizacaoAlertaDto dto)
    {
        var alerta = await _context.Alertas.FindAsync(id);

        if (alerta == null)
            return NotFound();

        alerta.Tipo = dto.Tipo;
        alerta.NivelRisco = dto.NivelRisco;
        alerta.Descricao = dto.Descricao;
        alerta.DataEmissao = dto.DataEmissao;
        alerta.OcorrenciaId = dto.OcorrenciaId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Remove um alerta.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var alerta = await _context.Alertas.FindAsync(id);

        if (alerta == null)
            return NotFound();

        _context.Alertas.Remove(alerta);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}