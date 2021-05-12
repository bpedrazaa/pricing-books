using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using UPB.PricingBooks.Data.Exceptions;
using UPB.PricingBooks.Logic.Exceptions;
using UPB.PricingBooks.Services.Exceptions;

namespace UPB.PricingBooks.Presentation.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
               await HandleException(httpContext, ex);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            int statusCode = GetCode(ex);
            string message = GetMessage(ex);

            var errorObj = new
            {
                StatusCode = statusCode,
                ErrorMessage = message
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)errorObj.StatusCode;
            await httpContext.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(errorObj));
        }
        private int GetCode(Exception ex)
        {
            int code=0;

            if(ex is ServiceException)
            {
                code = (int)HttpStatusCode.OK;
            }else if(ex is Data.Exceptions.InvalidProductDataException)
            {
                code = (int)HttpStatusCode.InternalServerError;
            }
            else if (ex is UPB.PricingBooks.Logic.Exceptions.InvalidProductDataException)
            {
                code = (int)HttpStatusCode.InternalServerError;
            }
            else if (ex is ListEmptyException)
            {
                code = (int)HttpStatusCode.InternalServerError;
            }else if(ex is DBException)
            {
                code = (int)HttpStatusCode.InternalServerError;
            }else if(ex is InvalidPricingBookDataException)
            {
                code = (int)HttpStatusCode.InternalServerError;
            }

            return code;
        }
        private string GetMessage(Exception ex)
        {
            string msg = "";
            if (ex is ServiceException)
            {
                msg = "Something went wrong while trying to connect with the services, more info :" + ex.Message;
            }
            else if(ex is Data.Exceptions.InvalidProductDataException)
            {
                msg = "Internal server error, more info :" + ex.Message;
            }
            else if (ex is Logic.Exceptions.InvalidProductDataException)
            {
                msg = "Error processing the product data, more info :" + ex.Message;
            }
            else if (ex is ListEmptyException)
            {
                msg = "Database is empty, more info :" + ex.Message;
            }
            else if (ex is DBException)
            {
                msg = "Database error, more info :" + ex.Message;
            }
            else if( ex is InvalidPricingBookDataException)
            {
                msg = "Error in server, more info :" + ex.Message;
            }
            return msg;
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
