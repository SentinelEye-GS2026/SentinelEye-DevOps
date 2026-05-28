using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentinelEye.Models;

/// <summary>
/// Representa um agente responsável pelo monitoramento.
/// </summary>
public class Agente
{
    /// <summary>
    /// Identificador único do agente.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome do agente.
    /// </summary>
    [Required]
    [StringLength(120)]
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Email do agente.
    /// </summary>
    [Required]
    [StringLength(120)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Cargo do agente.
    /// </summary>
    [Required]
    [StringLength(80)]
    public string Cargo { get; set; } = string.Empty;

    /// <summary>
    /// Chave estrangeira da região.
    /// </summary>
    [ForeignKey("Regiao")]
    public int RegiaoId { get; set; }

    /// <summary>
    /// Região relacionada ao agente.
    /// </summary>
    public Regiao Regiao { get; set; } = null!;
}