﻿// <copyright file="IgnoredRouteTestStartup.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Metrics.AspNetCore.Integration.Facts.Startup
{
    public class IgnoredRouteTestStartup : TestStartup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            SetupAppBuilder(app, env, loggerFactory);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appMetricsOptions = new MetricsOptions
                                    {
                                        DefaultContextLabel = "testing",
                                        MetricsEnabled = true
                                    };

            var appMetricsMiddlewareOptions = new MetricsAspNetCoreOptions
                                       {
                                           MetricsTextEndpointEnabled = true,
                                           MetricsEndpointEnabled = true,
                                           PingEndpointEnabled = true
                                       };

            appMetricsMiddlewareOptions.IgnoredRoutesRegexPatterns.Add("(?i)^api/test/ignore");

            SetupServices(services, appMetricsOptions, appMetricsMiddlewareOptions);
        }
    }
}