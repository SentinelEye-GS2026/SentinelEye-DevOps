namespace SentinelEye.DTOs.ImagemSateliteDTO;

public class LeituraImagemDto
{
    /// <summary>
    /// Identificador da imagem.
    /// </summary>
    public int Id { get; set; }

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
    /// Tipo da ocorrência relacionada.
    /// </summary>
    public string Ocorrencia { get; set; }
}