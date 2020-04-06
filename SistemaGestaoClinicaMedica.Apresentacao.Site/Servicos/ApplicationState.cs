﻿using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos
{
    public class InitApplicationState
    {
        public string Token { get; set; }
        public UsuarioLogado UsuarioLogado { get; set; }
        public bool EstaAutenticado { get; set; }
    }

    public class ApplicationState
    {
        public string _token;

        public ApplicationState(HttpClient httpClient)
        {
            HttpClient = httpClient;

        }

        public HttpClient HttpClient { get; }
        public string Token
        {
            get { return _token; }
            set
            {
                _token = value;

                if (!string.IsNullOrEmpty(_token))
                    HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
        }
        public UsuarioLogado UsuarioLogado { get; set; }
    }
}
