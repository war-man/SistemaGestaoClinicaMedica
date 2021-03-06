using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Dominio.Servicos
{
    public interface IMedicamentoServico : IServicoBase<Guid, Medicamento>
    {
        IList<Medicamento> ObterTudoPorNome(string nome);
        IList<Medicamento> ObterTudoComFiltros(string busca, bool ativo);
    }
}
