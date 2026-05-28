using System.ComponentModel.DataAnnotations;

namespace SentinelEye.Models;

/// <summary>
/// Representa uma região monitorada pelo sistema.
/// </summary>
public class Regiao
{
    /// <summary>
    /// Identificador único da região.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Nome da região monitorada.
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// País da região monitorada.
    /// </summary>
    [Required]
    [StringLength(80)]
    public string Pais { get; set; } = string.Empty;

    /// <summary>
    /// Nível de risco da região.
    /// </summary>
    [Required]
    [StringLength(30)]
    public string NivelRisco { get; set; } = string.Empty;

    /// <summary>
    /// Lista de ocorrências da região.
    /// </summary>
    public ICollection<Ocorrencia> Ocorrencias { get; set; }
        = new List<Ocorrencia>();

    /// <summary>
    /// Lista de agentes responsáveis pela região.
    /// </summary>
    public ICollection<Agente> Agentes { get; set; }
        = new List<Agente>();
}