using Northwind.IA.Sales.Gateways.EFCore.Options;
using Northwind.IA.Sales.Gateways.Smtp.Gateways.Options;

namespace Northwind.FD.Sales.WebApi;

public static class Startup
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddNorthwindSalesServices(
            dbOptions =>
                builder.Configuration.GetSection(DbOptions.SectionKey).Bind(dbOptions),
            smtpOptions => 
                builder.Configuration.GetSection(SmtpOptions.SectionKey).Bind(smtpOptions));

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
        app.UseExceptionHandler(builder => { });
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

