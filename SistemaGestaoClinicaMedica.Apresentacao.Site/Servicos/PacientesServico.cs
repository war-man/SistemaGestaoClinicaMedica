﻿using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class PacientesServico : ServicoBase<PacienteDTO, Guid>, IPacientesServico
    {
        public PacientesServico(IConfiguration configuration, ILocalStorageService localStorage) : base(configuration, localStorage) { }

        public async Task<PacienteDTO> GetPorCodigoAsync(string pacienteCodigo)
        {
            var response = await HttpClient.GetStringAsync($"{RequestUri}/por-codigo/{pacienteCodigo}");
            return JsonToDTO<PacienteDTO>(response);
        }
    }
}
