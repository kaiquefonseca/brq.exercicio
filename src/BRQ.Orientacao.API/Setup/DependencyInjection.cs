using BRQ.Orientacao.Domain;
using Microsoft.Extensions.DependencyInjection;


namespace BRQ.Orientacao.Presentation.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICombinacaoService, CombinacaoService>();
        }
    }
}
