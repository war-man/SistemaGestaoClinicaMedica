using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;

namespace SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao
{
    public interface ITipoDeExameServicoAplicacao : IServicoAplicacaoLeitura<TipoDeExameDTO, Guid>
    {
    }
}
