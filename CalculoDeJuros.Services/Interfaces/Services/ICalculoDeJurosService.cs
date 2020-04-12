using System;
using System.Threading.Tasks;

namespace CalculoDeJuros.Business.Interfaces.Services
{
    public interface ICalculoDeJurosService
    {
        Task<decimal> CalcularJurosCompostos(decimal valorInicial, int qtdMeses);
        
    }
}
