using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RouteManagment.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagement.Infraestructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BussinesExceptions bussinesException)
            {
                var (statusCode, title) = bussinesException.ErrorCode switch
                {
                    ErrorCode.NotFound => (404, "Not Found"),
                    ErrorCode.InvaliData => (400, "Bad Request"),
                    ErrorCode.Unauthorized => (401, "Unauthorized"),
                    ErrorCode.Forbidden => (404, "Forbidden"),
                    _ => (500, "Internal Server Error")

                };

                var response = new
                {
                    Status = statusCode,
                    Title = title,
                    Detail = bussinesException.ErrorMessage
                };
                context.Result = new ObjectResult(response)
                {
                    StatusCode = statusCode
                };
            }
         /*   else
            {
                var response = new
                {
                    Status = 500,
                    Title = "Internal Server Error",
                    Detail = "An unexpect error ocurred. "
                };

                context.Result = new ObjectResult(response)
                    { StatusCode = 500 };
            }*/
            context.ExceptionHandled = true;
        }
    }
}
