using System.Threading.Tasks;

namespace CalculoDeJuros.Business.Interfaces.Services
{
    public interface ITaxaDeJurosService
    {
        Task<double> BuscarTaxaDeJuros();
    }
}
