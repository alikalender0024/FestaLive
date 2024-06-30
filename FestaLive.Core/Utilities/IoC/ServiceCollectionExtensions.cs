﻿using Microsoft.Extensions.DependencyInjection;

namespace FestaLive.Core.Utilities.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }
            return services;
        }
    }
}
