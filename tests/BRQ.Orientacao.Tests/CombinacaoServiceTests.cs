using BRQ.Orientacao.Domain;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BRQ.Orientacao.Tests
{
    public class CombinacaoServiceTests
    {
        private readonly IMemoryCache _memoryCache;
        public CombinacaoServiceTests()
        {
            _memoryCache = GetMemoryCache();
        }
        

        [Theory]
        [Trait("Categoria", "Combinação Testes")]
        [InlineData("ab", 3, 8)]
        [InlineData("abcd", 2, 16)]
        public void GerarNovaPalavra_CriandoCombinacoes_DeveRetornarQuantidadeCombinacoesEsperadas(string letras, int tamanho, int combinacoesEsperadas)
        {
            //Arrange
            var combinacoesService = new CombinacaoService(_memoryCache);            
            List<string> resultado = new List<string>();

            //Act
            combinacoesService.GerarNovaPalavra(resultado, letras, "", tamanho);

            //Assert
            Assert.Equal(combinacoesEsperadas, resultado.Count);
        }

        [Fact]
        [Trait("Categoria", "Combinação Testes")]
        public void RetornarUltimaCombinacao_CriaCombinacaoESalvaNoCache_DeveConterCombinacao()
        {
            //Arrange
            var combinacoesService = new CombinacaoService(_memoryCache);
            string frase = "abcd";
            int tamanho = 2;
            List<string> resultado = new List<string>();
            combinacoesService.GerarNovaPalavra(resultado, frase, "", tamanho);

            //Act
            var ultimaCombinacao = combinacoesService.RetornarUltimaCombinacaoGerada();

            //Assert
            Assert.True(resultado.Count() > 0);
            Assert.True(ultimaCombinacao.Count() > 0);
            Assert.Equal(resultado, ultimaCombinacao);
        }

        private IMemoryCache GetMemoryCache()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();

            var memoryCache = serviceProvider.GetService<IMemoryCache>();
            return memoryCache;
        }
    }
}
