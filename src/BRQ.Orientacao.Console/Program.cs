using BRQ.Orientacao.Console.DTO;
using System;
using Microsoft.Extensions.Configuration;
using BRQ.Orientacao.Console.REST;
using System.Collections.Generic;

namespace BRQ.Orientacao.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", true, true)
           .Build();

            while (true)
            {
                CombinacaoRequestDTO combinacaoRequestDTO = new CombinacaoRequestDTO();

                System.Console.WriteLine("Insira o conjunto de caracteres:");
                combinacaoRequestDTO.Letras = System.Console.ReadLine();

                System.Console.WriteLine("Insira o comprimento total da combinação:");
                combinacaoRequestDTO.Tamanho = Convert.ToInt32(System.Console.ReadLine());

                string endPoint = $"{configuration.GetSection("UrlAPI").Value}/combinacao/gerar";

                var combinacoes = Requisicao.Post<List<string>>(new Uri(endPoint), combinacaoRequestDTO.ToObject(), new Dictionary<string, string>());

                foreach (var combinacao in combinacoes)
                {
                    System.Console.WriteLine(combinacao);
                }
            }

        }
    }
}
