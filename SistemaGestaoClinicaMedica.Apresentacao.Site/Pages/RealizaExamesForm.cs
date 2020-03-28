﻿using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class RealizaExamesForm
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }

        private async Task BuscarAsync(string busca)
        {
            _dto = await HttpServico.GetPorCodigoAsync(busca);
            Id = _dto.Id;
        }

        private async Task EnviarResultadoAsync(IFileListEntry[] files)
        {
            foreach (var file in files)
            {
                var uri = await HttpServico.UploadResultado(_dto.Id, file.Data, file.Name);
                _dto.LinkResultadoExame = uri.AbsoluteUri;
            }
        }

        protected async override Task Salvar(EditContext editContext)
        {
            if (string.IsNullOrEmpty(_dto.LinkResultadoExame))
            {
                ToastService.ShowWarning("Não foi realizado o envio do resultados!");
                return;
            }

            //_dto.StatusExame.Id = StatusExameConst.Concluido;
            //await base.Salvar(editContext);

            await HttpServico.PutAlterarStatusAsync(_dto.Id, StatusExameConst.Concluido);
            await JSRuntime.ForceReload();
        }
    }
}