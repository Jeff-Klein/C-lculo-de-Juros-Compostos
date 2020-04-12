using Autenticacao.API.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autenticacao.API.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObterPorUserNameAsync(string userName);
    }
}
