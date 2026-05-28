using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentinelEye.Models;

/// <summary>
/// Representa uma ocorrência detectada pelo sistema.
/// </summary>
public class Ocorrencia
{
    /// <summary>
    /// Identificador único da ocorrência.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Tipo da ocorrência.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Tipo { get; set; } = string.Empty;

    /// <summary>
    /// Descrição detalhada da ocorrência.
    /// </summary>
    [Required]
    [StringLength(500)]
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Data da ocorrência.
    /// </summary>
    [Required]
    public DateTime DataOcorrencia { get; set; }

    /// <summary>
    /// Latitude da ocorrência.
    /// </summary>
    [Required]
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude da ocorrência.
    /// </summary>
    [Required]
    public double Longitude { get; set; }

    /// <summary>
    /// Chave estrangeira da região.
    /// </summary>
    [ForeignKey("Regiao")]
    public int RegiaoId { get; set; }

    /// <summary>
    /// Região relacionada à ocorrência.
    /// </summary>
    public Regiao Regiao { get; set; } = null!;

    /// <summary>
    /// Lista de alertas relacionados.
    /// </summary>
    public ICollection<Alerta> Alertas { get; set; }
        = new List<Alerta>();

    /// <summary>
    /// Lista de imagens da ocorrência.
    /// </summary>
    public ICollection<ImagemSatelite> Imagens { get; set; }
        = new List<ImagemSatelite>();
}