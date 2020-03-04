﻿using Microsoft.Extensions.DependencyInjection;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using SistemaGestaoClinicaMedica.Dominio.Servicos;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos.Autenticacao;
using SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC.Extensions;
using SistemaGestaoClinicaMedica.Infra.Data.Queries;
using SistemaGestaoClinicaMedica.Infra.Data.Servicos;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static void Registrar(IServiceCollection services)
        {
            services.AddSingleton<IAutenticacaoServico, JwtAutenticacaoServico>();

            //services.AddScoped(typeof(IServicoBase<,>), typeof(ServicoBase<,>));

            services.RegistrarTudoPorAssembly(typeof(ILoginServicoAplicacao).Assembly, "ServicoAplicacao");

            services.RegistrarTudoPorAssembly(typeof(ServicoBase<,>).Assembly, "Servico");

            services.RegistrarTudoPorAssembly(typeof(QueryBase).Assembly, "Query");
        }
    }
}
