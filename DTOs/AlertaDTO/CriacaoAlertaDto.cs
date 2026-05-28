namespace SentinelEye.DTOs.AlertaDTO;

public class CriacaoAlertaDto
{
    /// <summary>
    /// Tipo do alerta.
    /// </summary>
    public string Tipo { get; set; }

    /// <summary>
    /// Nível de risco do alerta.
    /// </summary>
    public string NivelRisco { get; set; }

    /// <summary>
    /// Descrição do alerta.
    /// </summary>
    public string Descricao { get; set; }

    /// <summary>
    /// Data de emissão do alerta.
    /// </summary>
    public DateTime DataEmissao { get; set; }

    /// <summary>
    /// Ocorrência relacionada.
    /// </summary>
    public int OcorrenciaId { get; set; }
}