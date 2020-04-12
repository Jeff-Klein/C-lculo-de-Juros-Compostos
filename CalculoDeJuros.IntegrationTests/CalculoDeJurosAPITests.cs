using System.Threading.Tasks;
using Xunit;
using CalculoDeJuros.IntegrationTests.Config;

namespace CalculoDeJuros.IntegrationTests
{
    public class CalculoDeJurosAPITests
        : IClassFixture<CalculoDeJurosAPIFactory<CalculoDeJuros.API.Startup>>
    {
        private readonly CalculoDeJurosAPIFactory<CalculoDeJuros.API.Startup> _calculoDeJurosAPIFactory;

        public CalculoDeJurosAPITests(CalculoDeJurosAPIFactory<CalculoDeJuros.API.Startup> calculoDeJurosAPIFactory)
        {
            _calculoDeJurosAPIFactory = calculoDeJurosAPIFactory;
        }

        [Theory]
        [InlineData("/calculajuros?valorinicial=100&meses=5", "105.10")]
        [InlineData("/showmethecode", "https://github.com")]
        [Trait("Integração", "Status CalculoDeJuros.API")]
        public async Task CalculoDeJurosAPI_ValidarRetornoEndpoints(string url, string retornoEsperado)
        {

            // Arrange
            var calculoClient = _calculoDeJurosAPIFactory.CreateClient();

            // Act
            var response = await calculoClient.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/plain; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
            Assert.Equal(retornoEsperado, 
                response.Content.ReadAsStringAsync().Result);
        }
    }
}
