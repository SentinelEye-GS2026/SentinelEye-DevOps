namespace SentinelEye.DTOs.AgenteDTO;

public class LeituraAgenteDto
{
    /// <summary>
    /// Identificador do agente.
    /// </summary>
    public int Id { get; set; }

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
    /// Nome da região relacionada.
    /// </summary>
    public string Regiao { get; set; }
}