using System.Threading.Tasks;
using TaxaDeJuros.API.Dominio.Entidades;
using TaxaDeJuros.API.Dominio.Repositorios;

namespace TaxaDeJuros.API.Data.Repositorios
{
    //criei o respositório apenas para exemplificar, pois na vida real essa taxa viria de uma transação assincrona com o context do banco.
    public class TaxaRepositorio : ITaxaRepositorio
    {
        private readonly static Taxa TaxaDeJuros = new Taxa() { Nome = "Taxa de Juros", Percentual = 0.01 };

        public async Task<Taxa> ObterTaxaDeJurosAsync()
            => await Task.FromResult(TaxaDeJuros);
    }
}
