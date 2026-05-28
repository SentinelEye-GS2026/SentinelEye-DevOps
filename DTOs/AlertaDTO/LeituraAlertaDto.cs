namespace SentinelEye.DTOs.AlertaDTO;

public class LeituraAlertaDto
{
    /// <summary>
    /// Identificador do alerta.
    /// </summary>
    public int Id { get; set; }

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
    /// Tipo da ocorrência relacionada.
    /// </summary>
    public string Ocorrencia { get; set; }
}