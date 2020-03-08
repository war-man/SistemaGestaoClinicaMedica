﻿using SistemaGestaoClinicaMedica.Dominio.Entidades;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IExamesQuery : IQueryBase<Exame>
    {
        Exame Obter(string codigo);
    }
}