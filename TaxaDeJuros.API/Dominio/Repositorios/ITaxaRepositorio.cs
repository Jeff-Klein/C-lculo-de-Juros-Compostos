using System.Threading.Tasks;
using TaxaDeJuros.API.Dominio.Entidades;

namespace TaxaDeJuros.API.Dominio.Repositorios
{
    public interface ITaxaRepositorio
    {
        Task<Taxa> ObterTaxaDeJurosAsync();
    }
}
