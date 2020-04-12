using CalculoDeJuros.Business.Interfaces.Services;
using CalculoDeJuros.Business.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CalculoDeJuros.Tests
{
    public class CalculoDeJurosServiceTests
    {
        [Theory]
        [InlineData(100, 5, 0.01, 105.10)]
        [InlineData(1000, 12, 0.0210, 1283.24)]
        [InlineData(9999.99, 9, 0.0999, 23560.16)]
        [InlineData(9999999, 36, 0.1999, 7066784967.73)]
        [InlineData(5000000.00, 120, 0.09, 154935078745.97)]
        [Trait("Unidade", "Calculo de Juros Compostos")]
        public async Task CalculoDeJuros_RetornarValorComJurosCompostos(decimal valorInicial, int qtdMeses, double taxaDeJuros, decimal esperado)
        {
            //Arrange
            var taxaDeJurosService = new Mock<ITaxaDeJurosService>();
            taxaDeJurosService.Setup(s => s.BuscarTaxaDeJuros()).Returns(Task.FromResult(taxaDeJuros));
            var calculoDeJurosService = new CalculoDeJurosService(taxaDeJurosService.Object);

            //Act
            var valorFinal = await calculoDeJurosService.CalcularJurosCompostos(valorInicial, qtdMeses);

            //Assert
            Assert.Equal(valorFinal, esperado);
        }
    }
}
