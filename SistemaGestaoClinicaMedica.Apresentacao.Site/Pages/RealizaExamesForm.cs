using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class RealizaExamesForm
    {
        private bool _carregando;
        private bool _enviandoResultado;

        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ApplicationState ApplicationState { get; set; }

        private async Task BuscarAsync(string busca)
        {
            if (string.IsNullOrEmpty(busca) || busca.Length < 8)
            {
                ToastService.ShowInfo($"O código {busca} do exame está inválido!");
                return;
            }

            _carregando = true;
            StateHasChanged();

            _dto = await HttpServico.GetPorCodigoAsync(busca);

            if (_dto == null)
            {
                ToastService.ShowInfo($"Nenhum exame localizado com o código {busca}");
                _dto = new ExameDTO();
                _carregando = false;
                StateHasChanged();
                return;
            }

            Id = _dto.Id;

            _carregando = false;
            StateHasChanged();
        }

        private async Task EnviarResultadoAsync(IFileListEntry[] files)
        {
            _enviandoResultado = true;
            StateHasChanged();

            foreach (var file in files)
            {
                var uri = await HttpServico.UploadResultado(_dto.Id, file.Data, file.Name);
                _dto.LinkResultadoExame = uri.AbsoluteUri;
            }

            ToastService.ShowSuccess($"Resultado do exame de código {_dto.Codigo} foi enviado!");

            _enviandoResultado = false;
            StateHasChanged();
        }

        protected async override Task<bool> Salvar(EditContext editContext)
        {
            _carregando = true;
            StateHasChanged();

            if (string.IsNullOrEmpty(_dto.LinkResultadoExame) && _dto.StatusExame.Id == StatusExameConst.EmAnaliseLaboratorial)
            {
                ToastService.ShowWarning("Não foi realizado o envio do resultados!");
                _carregando = false;
                StateHasChanged();
                return false;
            }

            _dto.LaboratorioRealizouExameId = ApplicationState.UsuarioLogado.Id;
            _dto.StatusExame.Id = _dto.StatusExame.Id == StatusExameConst.Pendente ? StatusExameConst.EmAnaliseLaboratorial : StatusExameConst.Concluido;

            await HttpServico.PutAsync(_dto.Id, _dto);
            await JSRuntime.ForceReloadAsync();
            return true;
        }
    }
}
