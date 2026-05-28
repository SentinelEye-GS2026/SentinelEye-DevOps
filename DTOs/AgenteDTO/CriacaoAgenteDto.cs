namespace SentinelEye.DTOs.AgenteDTO;

public class CriacaoAgenteDto
{
    /// <summary>
    /// Nome do agente.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Email do agente.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Cargo do agente.
    /// </summary>
    public string Cargo { get; set; }

    /// <summary>
    /// Região relacionada.
    /// </summary>
    public int RegiaoId { get; set; }
}