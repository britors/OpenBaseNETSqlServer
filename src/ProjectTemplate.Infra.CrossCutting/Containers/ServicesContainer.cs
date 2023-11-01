﻿using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Infra.CrossCutting.Context;

namespace ProjectTemplate.Infra.CrossCutting.Containers;

internal static class ServicesContainer
{
    internal static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<SessionContext>();
    }
}