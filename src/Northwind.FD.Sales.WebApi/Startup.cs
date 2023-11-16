using Northwind.IA.Sales.Gateways.EFCore.Options;

namespace Northwind.FD.Sales.WebApi;

public static class Startup
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddNorthwindSalesServices(dbOptions =>
        builder.Configuration.GetSection(DbOptions.SectionKey).Bind(dbOptions));

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });
        });

        return builder.Build();
    }


    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        if(app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapNorthwindSalesEndpoints();
        app.UseCors();

        return app;
    }
}

