using System.Collections.Generic;

namespace BRQ.Orientacao.Domain
{
    public interface ICombinacaoService
    {
        void GerarNovaPalavra(List<string> resultado, string palavra, string palavraAtual, int tamanho);

        IEnumerable<string> RetornarUltimaCombinacaoGerada();
    }
}
