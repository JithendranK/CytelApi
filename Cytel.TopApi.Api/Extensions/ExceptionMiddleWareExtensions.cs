using Contracts;
using Cytel.Top.Api.Messages;
using Cytel.Top.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cytel.Top.Api.Extensions
{
    public static class ExceptionMiddleWareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app,ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    string errorMsg = contextFeature.Error.ToString();
                    string errorCode = context.Response.StatusCode.ToString();

                    if (contextFeature !=null)
                    {
                        if(contextFeature.Error is DivideByZeroException)
                        {
                            errorMsg = MessageResponses.ErrorMessages[MessageCodes.Message.DivideByZeroException.ToString()];
                            errorCode = $"CY-{((int)MessageCodes.Message.DivideByZeroException).ToString()}";
                        }
                        
                       
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            ErrorCode= errorCode,
                            Message = "Internal Server Error"
                        }.ToString());
                    }
                });
            });
         
        }
    }
}
