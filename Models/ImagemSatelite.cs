using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentinelEye.Models;

/// <summary>
/// Representa uma imagem de satélite associada a uma ocorrência.
/// </summary>
public class ImagemSatelite
{
    /// <summary>
    /// Identificador único da imagem.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// URL da imagem.
    /// </summary>
    [Required]
    [StringLength(300)]
    public string UrlImagem { get; set; } = string.Empty;

    /// <summary>
    /// Fonte da imagem.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Fonte { get; set; } = string.Empty;

    /// <summary>
    /// Data da captura da imagem.
    /// </summary>
    [Required]
    public DateTime DataCaptura { get; set; }

    /// <summary>
    /// Chave estrangeira da ocorrência.
    /// </summary>
    [ForeignKey("Ocorrencia")]
    public int OcorrenciaId { get; set; }

    /// <summary>
    /// Ocorrência relacionada à imagem.
    /// </summary>
    public Ocorrencia Ocorrencia { get; set; } = null!;
}