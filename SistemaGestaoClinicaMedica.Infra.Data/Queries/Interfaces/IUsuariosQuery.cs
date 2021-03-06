using SistemaGestaoClinicaMedica.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaGestaoClinicaMedica.Infra.Data.Queries
{
    public interface IUsuariosQuery : IQueryBase<Usuario>
    {
        Usuario Autorizar(string email, string senha);
        IList<Usuario> ObterTudoComFiltros(string busca, bool ativo);
        Usuario ObterPorEmail(string email);
    }
}
