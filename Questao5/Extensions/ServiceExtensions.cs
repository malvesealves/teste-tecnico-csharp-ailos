using Questao5.Infrastructure.Database.Handlers;

namespace Questao5.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationHandlers(this IServiceCollection services)
        {
            services.AddScoped<Application.Handlers.CreateIdempotencyHandler>();
            services.AddScoped<Application.Handlers.CreateMovementHandler>();
            services.AddScoped<Application.Handlers.GetBalanceHandler>();
            services.AddScoped<Application.Handlers.GetIdempotencyHandler>();
        }

        public static void ConfigureInfrastructureHandlers(this IServiceCollection services)
        {
            services.AddScoped<CreateIdempotencyHandler>();
            services.AddScoped<CreateMovementHandler>();
            services.AddScoped<GetAccountByIdHandler>();
            services.AddScoped<GetIdempotencyHandler>();
            services.AddScoped<GetMovementsByAccountHandler>();
        }
    }
}
