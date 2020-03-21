﻿using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public interface IEspecialidadeServico : IServicoLeituraBase<EspecialidadeDTO, Guid>
    {
        Task<List<EspecialidadeDTO>> GetDisponiveisAsync();
    }
}
