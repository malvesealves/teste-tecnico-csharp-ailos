namespace Questao5.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationHandlers(this IServiceCollection services)
        {
            services.AddScoped<Application.Handlers.CreateIdempotencyHandler>();
        }

        public static void ConfigureInfrastructureHandlers(this IServiceCollection services)
        {
            services.AddScoped<Infrastructure.Database.CommandStore.Handlers.CreateIdempotencyHandler>();
        }
    }
}
