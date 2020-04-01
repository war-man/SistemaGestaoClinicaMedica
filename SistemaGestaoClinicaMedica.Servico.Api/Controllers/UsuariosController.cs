﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoClinicaMedica.Aplicacao.ServicosAplicacao;
using System;

namespace SistemaGestaoClinicaMedica.Servico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServicoAplicacao _usuarioServicoAplicacao;

        public UsuariosController(IUsuarioServicoAplicacao usuarioServicoAplicacao)
        {
            _usuarioServicoAplicacao = usuarioServicoAplicacao;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get(bool ativo = true)
        {
            var saidaDTOs = _usuarioServicoAplicacao.ObterTudo(ativo);
            return Ok(saidaDTOs);
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _usuarioServicoAplicacao.Deletar(id);
            return Ok();
        }
    }
}