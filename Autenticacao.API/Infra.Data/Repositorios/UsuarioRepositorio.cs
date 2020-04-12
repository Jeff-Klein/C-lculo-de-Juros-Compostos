using Autenticacao.API.Dominio.Entidades;
using Autenticacao.API.Dominio.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao.API.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly static ICollection<Usuario> Usuarios = new List<Usuario>() { new Usuario() { Username = "admin", Senha = "admin" } };

        public async Task<Usuario> ObterPorUserNameAsync(string userName)
            => await Task.FromResult(Usuarios.Where(u => u.Username == userName).FirstOrDefault());

    }
}
