﻿namespace Ordering.API
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // services.AddCarter();
            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
           // app.MapCarter();
            return app;
        }
    }
}
