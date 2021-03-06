using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IExamesServico : IServicoBase<ExameDTO, Guid>
    {
        Task<ExameDTO> GetPorCodigoAsync(string codigo);
        Task<Uri> UploadResultado(Guid id, Stream stream, string arquivoNome);
        Task<HttpResponseMessage> PutAlterarStatusAsync(Guid id, string statusExameId);
        Task<List<ExameDTO>> GetPorConsultaAsync(Guid consultaId);
        Task<List<ExameDTO>> GetTudoComFiltrosAsync(string busca, string status, Guid? medicoId);
        Task<ChartJSDataset> GetTotalExamesAsync(DateTime dataInicio, DateTime dataFim);
    }
}
