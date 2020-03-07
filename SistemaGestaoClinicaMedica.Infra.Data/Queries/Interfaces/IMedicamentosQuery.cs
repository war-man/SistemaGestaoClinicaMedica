﻿using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IMedicamentosQuery : IQueryBase<Medicamento>
    {
        IList<Medicamento> ObterTudo(string busca, bool ativo);
    }
}
