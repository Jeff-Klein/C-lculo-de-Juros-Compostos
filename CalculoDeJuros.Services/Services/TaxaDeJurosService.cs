using CalculoDeJuros.Business.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculoDeJuros.Business.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        private readonly string _taxaDeJurosAPIBaseUrl;

        public TaxaDeJurosService() { }

        public TaxaDeJurosService(IConfiguration cfg)
        {
            _taxaDeJurosAPIBaseUrl = cfg.GetSection("Apis").GetSection("TaxaDeJurosAPI").Value;
        }

        public async Task<double> BuscarTaxaDeJuros()
        {
            var uri = string.Concat(_taxaDeJurosAPIBaseUrl, "taxaJuros");
            
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(uri);
                return Convert.ToDouble(response);
            }
        }
    }
}
