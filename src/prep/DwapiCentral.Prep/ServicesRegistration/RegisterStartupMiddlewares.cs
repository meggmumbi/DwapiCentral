using DwapiCentral.Prep.Infrastructure.Persistence.Context;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DwapiCentral.Prep.ServicesRegistration;

public static class RegisterStartupMiddlewares
{
    public static WebApplication SetupMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DefaultModelsExpandDepth(-1);
            });
        }

        app.UseHttpsRedirection();

        app.UseHangfireDashboard("/hangfire");



        app.UseAuthorization();

        app.MapControllers();

        Log.Debug("starting prep...");
        SeedData(app);
        return app;
    }

    private static void SeedData(WebApplication app)
    {

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetService<PrepDbContext>();
            try
            {
                context.Database.Migrate();
                context.EnsureSeeded();
                Log.Debug($"initializing Database [OK]");
            }
            catch (Exception e)
            {
                Log.Error(e, $"initializing Database Error");
            }
        }
    }
}