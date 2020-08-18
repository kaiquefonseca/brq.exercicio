using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRQ.Orientacao.Domain;
using BRQ.Orientacao.Presentation.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.Orientacao.Presentation.Controllers
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