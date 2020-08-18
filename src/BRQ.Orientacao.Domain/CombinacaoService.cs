using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ.Orientacao.Domain
{
    public class CombinacaoService : ICombinacaoService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string chaveCache = "ultima_combinacao_gerada";

        public CombinacaoService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void GerarNovaPalavra(List<string> combinacaoCaracteres, string letras, string palavraAtual, int tamanho)
        {
            string palavraCorrente = palavraAtual;

            for (int i = 0; i < letras.Length; i++)
            {
                palavraCorrente += letras.ToCharArray()[i];

                if (palavraCorrente.Length >= tamanho)
                {
                    combinacaoCaracteres.Add(palavraCorrente);
                    palavraCorrente = palavraAtual;
                }
                else
                {
                    GerarNovaPalavra(combinacaoCaracteres, letras, palavraCorrente, tamanho);
                    palavraCorrente = palavraAtual;
                }
            }

            _memoryCache.Set(chaveCache, combinacaoCaracteres);
        }

        public IEnumerable<string> RetornarUltimaCombinacaoGerada()
        {
            var ultimaCombinacao = _memoryCache.Get<IEnumerable<string>>(chaveCache);

            if (ultimaCombinacao == null)
                return new List<string>();

            return ultimaCombinacao;
        }


    }
}
