using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SentinelEye.Data;
using SentinelEye.DTOs.ImagemSateliteDTO;
using SentinelEye.Models;

namespace SentinelEye.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagensSateliteController : ControllerBase
{
    private readonly AppDbContext _context;

    public ImagensSateliteController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Lista todas as imagens satélite.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeituraImagemDto>>> Get()
    {
        var imagens = await _context.ImagensSatelite
            .Include(i => i.Ocorrencia)
            .Select(i => new LeituraImagemDto
            {
                Id = i.Id,
                UrlImagem = i.UrlImagem,
                Fonte = i.Fonte,
                DataCaptura = i.DataCaptura,
                Ocorrencia = i.Ocorrencia.Tipo
            })
            .ToListAsync();

        return Ok(imagens);
    }

    /// <summary>
    /// Busca uma imagem pelo ID.
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<LeituraImagemDto>> GetById(int id)
    {
        var imagem = await _context.ImagensSatelite
            .Include(i => i.Ocorrencia)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (imagem == null)
            return NotFound();

        return Ok(new LeituraImagemDto
        {
            Id = imagem.Id,
            UrlImagem = imagem.UrlImagem,
            Fonte = imagem.Fonte,
            DataCaptura = imagem.DataCaptura,
            Ocorrencia = imagem.Ocorrencia.Tipo
        });
    }

    /// <summary>
    /// Lista imagens por ocorrência.
    /// </summary>
    [HttpGet("ocorrencia/{ocorrenciaId}")]
    public async Task<ActionResult<IEnumerable<LeituraImagemDto>>> GetPorOcorrencia(int ocorrenciaId)
    {
        var imagens = await _context.ImagensSatelite
            .Include(i => i.Ocorrencia)
            .Where(i => i.OcorrenciaId == ocorrenciaId)
            .Select(i => new LeituraImagemDto
            {
                Id = i.Id,
                UrlImagem = i.UrlImagem,
                Fonte = i.Fonte,
                DataCaptura = i.DataCaptura,
                Ocorrencia = i.Ocorrencia.Tipo
            })
            .ToListAsync();

        return Ok(imagens);
    }

    /// <summary>
    /// Cadastra uma nova imagem satélite.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post(CriacaoImagemDto dto)
    {
        var ocorrenciaExiste = await _context.Ocorrencias
            .AnyAsync(o => o.Id == dto.OcorrenciaId);

        if (!ocorrenciaExiste)
            return BadRequest("Ocorrência não encontrada.");

        var imagem = new ImagemSatelite
        {
            UrlImagem = dto.UrlImagem,
            Fonte = dto.Fonte,
            DataCaptura = dto.DataCaptura,
            OcorrenciaId = dto.OcorrenciaId
        };

        _context.ImagensSatelite.Add(imagem);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = imagem.Id }, imagem);
    }

    /// <summary>
    /// Atualiza uma imagem satélite.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, AtualizacaoImagemDto dto)
    {
        var imagem = await _context.ImagensSatelite.FindAsync(id);

        if (imagem == null)
            return NotFound();

        imagem.UrlImagem = dto.UrlImagem;
        imagem.Fonte = dto.Fonte;
        imagem.DataCaptura = dto.DataCaptura;
        imagem.OcorrenciaId = dto.OcorrenciaId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Remove uma imagem satélite.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var imagem = await _context.ImagensSatelite.FindAsync(id);

        if (imagem == null)
            return NotFound();

        _context.ImagensSatelite.Remove(imagem);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}