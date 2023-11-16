﻿namespace Microsoft.AspNetCore.Builder;
public static class EndpointsContainer
{
    public static WebApplication MapNorthwindSalesEndpoints(this WebApplication app)
    {
        app.UseCreateOrderController();

        return app;
    }
}
