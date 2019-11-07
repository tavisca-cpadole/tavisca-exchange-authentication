using AuthenticationPortal.Contracts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationPortal.Web
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var customException = exception as BaseException;
            int StatusCode = (int)HttpStatusCode.InternalServerError;
            CustomErrorResponse customErrorResponse = new CustomErrorResponse()
            {
                Code = StatusCode,
                Message = "Unexpected Error Occured"
            };

            if (customException != null)
            {
                customErrorResponse.Message = customException.Message;
                customErrorResponse.Code = customException.Code;
                StatusCode = (int)customException.StatusCode;
                customErrorResponse.Info = customException.Info;
            }

            response.ContentType = "application/json";
            response.StatusCode = StatusCode;

            return response.WriteAsync(JsonConvert.SerializeObject(customErrorResponse, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
