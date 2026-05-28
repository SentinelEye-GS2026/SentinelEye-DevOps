namespace SentinelEye.DTOs.ImagemSateliteDTO;

public class AtualizacaoImagemDto
{
    /// <summary>
    /// URL da imagem satélite.
    /// </summary>
    public string UrlImagem { get; set; }

    /// <summary>
    /// Fonte da imagem.
    /// </summary>
    public string Fonte { get; set; }

    /// <summary>
    /// Data da captura.
    /// </summary>
    public DateTime DataCaptura { get; set; }

    /// <summary>
    /// Ocorrência relacionada.
    /// </summary>
    public int OcorrenciaId { get; set; }
}