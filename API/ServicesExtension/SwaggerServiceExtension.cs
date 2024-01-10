namespace API.ServicesExtension
{
    public class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerServices (IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            return services;
        }
        
        public static WebApplication AddSwaggerServices (WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI();

            return app;
        }
    }
}