namespace SentinelEye.DTOs.RegiaoDTO;

public class LeituraRegiaoDto
{
    /// <summary>
    /// Identificador da região.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome da região monitorada.
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// País da região.
    /// </summary>
    public string Pais { get; set; }

    /// <summary>
    /// Nível de risco atual.
    /// </summary>
    public string NivelRisco { get; set; }
}