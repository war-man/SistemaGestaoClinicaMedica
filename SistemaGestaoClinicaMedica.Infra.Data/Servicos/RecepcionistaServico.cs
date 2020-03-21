﻿using Microsoft.EntityFrameworkCore;
using SistemaGestaoClinicaMedica.Dominio.Entidades;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using System;
using System.Linq;

namespace SistemaGestaoClinicaMedica.Infra.Data.Servicos
{
    public sealed class RecepcionistaServico : ServicoBase<Guid, Recepcionista>, IRecepcionistaServico
    {
        public RecepcionistaServico(ContextoBancoDados contextoBancoDados) : base(contextoBancoDados)
        {
        }

        public override Recepcionista Obter(Guid id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return Entidades.AsNoTracking().SingleOrDefault(_ => _.Id == id || _.Funcionario.Id == id);

            return Entidades.SingleOrDefault(_ => _.Id == id || _.Funcionario.Id == id);
        }
    }
}
