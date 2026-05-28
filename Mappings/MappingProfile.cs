using AutoMapper;
using SentinelEye.DTOs.AgenteDTO;
using SentinelEye.DTOs.AlertaDTO;
using SentinelEye.DTOs.ImagemSateliteDTO;
using SentinelEye.DTOs.OcorrenciaDTO;
using SentinelEye.DTOs.RegiaoDTO;
using SentinelEye.Models;

namespace SentinelEye.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ALERTA

        CreateMap<Alerta, LeituraAlertaDto>();

        CreateMap<CriacaoAlertaDto, Alerta>();

        CreateMap<AtualizacaoAlertaDto, Alerta>();


        // REGIAO
        

        CreateMap<Regiao, LeituraRegiaoDto>();

        CreateMap<CriacaoRegiaoDto, Regiao>();

        CreateMap<AtualizacaoRegiaoDto, Regiao>();


        // OCORRENCIA

        CreateMap<Ocorrencia, LeituraOcorrenciaDto>();

        CreateMap<CriacaoOcorrenciaDto, Ocorrencia>();

        CreateMap<AtualizacaoOcorrenciaDto, Ocorrencia>();


        // IMAGEM SATELITE
        

        CreateMap<ImagemSatelite, LeituraImagemDto>();

        CreateMap<CriacaoImagemDto, ImagemSatelite>();

        CreateMap<AtualizacaoImagemDto, ImagemSatelite>();


        // AGENTE

        CreateMap<Agente, LeituraAgenteDto>();

        CreateMap<CriacaoAgenteDto, Agente>();

        CreateMap<AtualizacaoAgenteDto, Agente>();
    }
}