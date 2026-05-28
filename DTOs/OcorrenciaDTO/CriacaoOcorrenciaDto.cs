namespace SentinelEye.DTOs.OcorrenciaDTO;

public class CriacaoOcorrenciaDto
{
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
    /// Região relacionada.
    /// </summary>
    public int RegiaoId { get; set; }
}