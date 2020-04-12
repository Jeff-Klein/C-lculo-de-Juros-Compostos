using CalculoDeJuros.Business.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace CalculoDeJuros.Business.Services
{
    public class CalculoDeJurosService : ICalculoDeJurosService
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;

        public CalculoDeJurosService(ITaxaDeJurosService taxaDeJurosService)
        {
            _taxaDeJurosService = taxaDeJurosService;
        }

        public async Task<decimal> CalcularJurosCompostos(decimal valorInicial, int qtdMeses)
        {
            var juros = await _taxaDeJurosService.BuscarTaxaDeJuros();

            var valorFinal = valorInicial * (decimal)Math.Pow(juros + 1, qtdMeses);
            valorFinal = Math.Truncate(100 * valorFinal) / 100;

            return valorFinal;
        }
    }
}
