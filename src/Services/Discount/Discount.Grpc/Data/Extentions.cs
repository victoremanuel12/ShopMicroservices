using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public static class Extentions
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            context.Database.MigrateAsync();
        }
    }
}
