using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class ConsultasForm
    {
        private bool _podeConcluirConsulta;

        [Inject] private IJSRuntime JSRuntime { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            _podeConcluirConsulta = _dto.StatusConsultaId == StatusConsultaConst.Agendada
                                 || _dto.StatusConsultaId == StatusConsultaConst.Reagendada;
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            await JSRuntime.ShowTabFromUrlIdAsync();
        }

        protected override Task<bool> Salvar(EditContext editContext)
        {
            if (_dto.StatusConsultaId == StatusConsultaConst.Agendada || _dto.StatusConsultaId == StatusConsultaConst.Reagendada)
                _dto.StatusConsultaId = StatusConsultaConst.Concluida;

            return base.Salvar(editContext);
        }
    }
}
