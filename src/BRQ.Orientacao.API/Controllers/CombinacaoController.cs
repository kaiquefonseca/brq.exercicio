using System.Collections.Generic;
using BRQ.Orientacao.Domain;
using BRQ.Orientacao.Presentation.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.Orientacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombinacaoController : ControllerBase
    {
        private readonly ICombinacaoService _combinacaoService;

        public CombinacaoController(ICombinacaoService combinacaoService)
        {
            _combinacaoService = combinacaoService;
        }

        [HttpGet("ultimaGeracao")]
        public IEnumerable<string> UltimaGeracao()
        {
            return _combinacaoService.RetornarUltimaCombinacaoGerada();
        }

        [HttpPost("gerar")]
        public List<string> Gerar([FromBody] CombinacaoRequestDTO combinacaoRequest)
        {
            List<string> combinacao = new List<string>();

            _combinacaoService.GerarNovaPalavra(combinacao, combinacaoRequest.Letras, "", combinacaoRequest.Tamanho);

            return combinacao;
        }
    }
}
