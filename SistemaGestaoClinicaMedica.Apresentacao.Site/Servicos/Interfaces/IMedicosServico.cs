﻿using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IMedicosServico : IServicoBase<MedicoDTO, Guid>
    {
        Task<List<MedicoDTO>> GetPorEspecialidadeAsync(Guid especialidadeId);
    }
}
