using Northwind.FD.Sales.WebApi.Extensions;

namespace Northwind.FD.Sales.WebApi;

public static class Startup
{
    public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerService();

        builder.Services.AddNorthwindSalesServices(
            dbOptions =>
                builder.Configuration.GetSection(DbOptions.SectionKey).Bind(dbOptions),
            smtpOptions =>
                builder.Configuration.GetSection(SmtpOptions.SectionKey).Bind(smtpOptions),
            membershipOptions =>
                builder.Configuration.GetSection(MembershipOptions.SectionKey).Bind(membershipOptions),
            jwtOptions =>
            builder.Configuration.GetSection(JwtOptions.SectionKey).Bind(jwtOptions));

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var jwtConfigurationSection = builder.Configuration.GetSection(JwtOptions.SectionKey);

                jwtConfigurationSection.Bind(options.TokenValidationParameters);
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfigurationSection[nameof(JwtOptions.SecurityKey)]));
            });

        builder.Services.AddAuthorization();

        return builder.Build();
    }


    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        app.UseExceptionHandler(builder => { });
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapNorthwindSalesEndpoints();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}

