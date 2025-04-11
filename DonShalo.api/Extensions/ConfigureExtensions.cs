﻿using DonShalo.api.Middlewares;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Text.Json;

namespace DonShalo.api.Extensions
{
    public static class ConfigureExtensions
    {
        public static IApplicationBuilder UserCustomExceptionHandler(this IApplicationBuilder builder, IWebHostEnvironment env)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>(env);
        }

        public static Task WriteResponseHealth(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            var options = new JsonWriterOptions
            {
                Indented = true
            };
            var objJson = new
            {
                status = result.Status.ToString()
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(objJson));
        }
    }
}
