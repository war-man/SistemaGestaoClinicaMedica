using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IAtestadoServico : IServicoBase<Guid, Atestado>
    {
        IList<Atestado> ObterTudoPorConsultaId(Guid consultaId);
    }
}
