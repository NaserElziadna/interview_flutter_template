using AutoWrapper;
using Microsoft.AspNetCore.Builder;

namespace PizzaBE.RestApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddMyResposeWrapper(this IApplicationBuilder app)
        {
            return app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions
            {
                UseApiProblemDetailsException = true,
                EnableExceptionLogging = true,
                EnableResponseLogging = true,
                LogRequestDataOnException = true,
                ShowApiVersion = true,
                ShowStatusCode = true,
                ShowIsErrorFlagForSuccessfulResponse = true,
                ShouldLogRequestData = true,
                UseCustomSchema = true,
                IsApiOnly = false,
                IsDebug = true//dispay the full error in the response 
            });
        }
    }
}
