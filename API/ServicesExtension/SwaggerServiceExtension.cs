namespace API.ServicesExtension
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            return services;
        }
        
        public static WebApplication UseSwaggerMiddleware(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI();

            return app;
        }
    }
}