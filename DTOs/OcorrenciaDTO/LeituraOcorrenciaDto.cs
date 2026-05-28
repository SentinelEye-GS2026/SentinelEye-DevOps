namespace SentinelEye.DTOs.OcorrenciaDTO;

public class LeituraOcorrenciaDto
{
    /// <summary>
    /// Identificador da ocorrência.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Tipo da ocorrência.
    /// </summary>
    public string Tipo { get; set; }

    /// <summary>
    /// Descrição da ocorrência.
    /// </summary>
    public string Descricao { get; set; }

    /// <summary>
    /// Data da ocorrência.
    /// </summary>
    public DateTime DataOcorrencia { get; set; }

    /// <summary>
    /// Nome da região relacionada.
    /// </summary>
    public string Regiao { get; set; }
}