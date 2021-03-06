using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaServicoAplicacao _receitaServicoAplicacao;

        public ReceitasController(IReceitaServicoAplicacao receitaServicoAplicacao)
        {
            _receitaServicoAplicacao = receitaServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpGet, Route("por-consulta/{consultaId}")]
        public IActionResult GetPorConsulta(Guid consultaId)
        {
            var saidaDTO = _receitaServicoAplicacao.ObterPorConsultaId(consultaId);
            return Ok(saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _receitaServicoAplicacao.Deletar(id);
            return Ok();
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpPost]
        public IActionResult Post([FromBody]ReceitaDTO entradaDTO)
        {
            var saidaDTO = _receitaServicoAplicacao.Salvar(entradaDTO);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }

        [Authorize("Bearer", Roles = "Administrador, Medico")]
        [HttpPut, Route("{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]ReceitaDTO entradaDTO)
        {
            var saidaDTO = _receitaServicoAplicacao.Salvar(entradaDTO, id);

            if (saidaDTO == null)
                return BadRequest();

            return Created($"/{saidaDTO.Id}", saidaDTO);
        }
    }
}