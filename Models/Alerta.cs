using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentinelEye.Models;

/// <summary>
/// Representa um alerta gerado pelo sistema.
/// </summary>
public class Alerta
{
    /// <summary>
    /// Identificador único do alerta.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Tipo do alerta.
    /// </summary>
    [Required]
    [StringLength(80)]
    public string Tipo { get; set; } = string.Empty;

    /// <summary>
    /// Nível de risco do alerta.
    /// </summary>
    [Required]
    [StringLength(30)]
    public string NivelRisco { get; set; } = string.Empty;

    /// <summary>
    /// Descrição do alerta.
    /// </summary>
    [Required]
    [StringLength(400)]
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// Data de emissão do alerta.
    /// </summary>
    [Required]
    public DateTime DataEmissao { get; set; }

    /// <summary>
    /// Chave estrangeira da ocorrência.
    /// </summary>
    [ForeignKey("Ocorrencia")]
    public int OcorrenciaId { get; set; }

    /// <summary>
    /// Ocorrência relacionada ao alerta.
    /// </summary>
    public Ocorrencia Ocorrencia { get; set; } = null!;
}