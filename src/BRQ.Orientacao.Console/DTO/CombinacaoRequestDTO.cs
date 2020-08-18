using Newtonsoft.Json;

namespace BRQ.Orientacao.Console.DTO
{
    public class CombinacaoRequestDTO
    {
        public string Letras { get; set; }
        public int Tamanho { get; set; }

        public string ToObject()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
