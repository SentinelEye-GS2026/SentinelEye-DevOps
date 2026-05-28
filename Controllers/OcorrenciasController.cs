using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.DTOs.OcorrenciaDTO;
using SentinelEye.Models;

namespace SentinelEye.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OcorrenciasController : ControllerBase
{
    private readonly AppDbContext _context;

    public OcorrenciasController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Lista todas as ocorrências.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeituraOcorrenciaDto>>> Get()
    {
        var ocorrencias = await _context.Ocorrencias
            .Include(o => o.Regiao)
            .Select(o => new LeituraOcorrenciaDto
            {
                Id = o.Id,
                Tipo = o.Tipo,
                Descricao = o.Descricao,
                DataOcorrencia = o.DataOcorrencia,
                Regiao = o.Regiao.Nome
            })
            .ToListAsync();

        return Ok(ocorrencias);
    }

    /// <summary>
    /// Busca uma ocorrência pelo ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeituraOcorrenciaDto>> GetById(int id)
    {
        var ocorrencia = await _context.Ocorrencias
            .Include(o => o.Regiao)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (ocorrencia == null)
            return NotFound();

        return Ok(new LeituraOcorrenciaDto
        {
            Id = ocorrencia.Id,
            Tipo = ocorrencia.Tipo,
            Descricao = ocorrencia.Descricao,
            DataOcorrencia = ocorrencia.DataOcorrencia,
            Regiao = ocorrencia.Regiao.Nome
        });
    }

    /// <summary>
    /// Lista ocorrências por região.
    /// </summary>
    [HttpGet("regiao/{regiaoId}")]
    public async Task<ActionResult<IEnumerable<LeituraOcorrenciaDto>>> GetPorRegiao(int regiaoId)
    {
        var ocorrencias = await _context.Ocorrencias
            .Include(o => o.Regiao)
            .Where(o => o.RegiaoId == regiaoId)
            .Select(o => new LeituraOcorrenciaDto
            {
                Id = o.Id,
                Tipo = o.Tipo,
                Descricao = o.Descricao,
                DataOcorrencia = o.DataOcorrencia,
                Regiao = o.Regiao.Nome
            })
            .ToListAsync();

        return Ok(ocorrencias);
    }

    /// <summary>
    /// Cadastra uma nova ocorrência.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post(CriacaoOcorrenciaDto dto)
    {
        var regiaoExiste = await _context.Regioes
            .AnyAsync(r => r.Id == dto.RegiaoId);

        if (!regiaoExiste)
            return BadRequest("Região não encontrada.");

        var ocorrencia = new Ocorrencia
        {
            Tipo = dto.Tipo,
            Descricao = dto.Descricao,
            DataOcorrencia = dto.DataOcorrencia,
            RegiaoId = dto.RegiaoId
        };

        _context.Ocorrencias.Add(ocorrencia);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = ocorrencia.Id }, ocorrencia);
    }

    /// <summary>
    /// Atualiza uma ocorrência.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, AtualizacaoOcorrenciaDto dto)
    {
        var ocorrencia = await _context.Ocorrencias.FindAsync(id);

        if (ocorrencia == null)
            return NotFound();

        ocorrencia.Tipo = dto.Tipo;
        ocorrencia.Descricao = dto.Descricao;
        ocorrencia.DataOcorrencia = dto.DataOcorrencia;
        ocorrencia.RegiaoId = dto.RegiaoId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Remove uma ocorrência.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var ocorrencia = await _context.Ocorrencias.FindAsync(id);

        if (ocorrencia == null)
            return NotFound();

        _context.Ocorrencias.Remove(ocorrencia);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}