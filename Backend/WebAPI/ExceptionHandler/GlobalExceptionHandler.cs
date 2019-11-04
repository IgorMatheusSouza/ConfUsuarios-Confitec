namespace WebAPI.ExceptionHandler
{
    using System.Data.SqlClient;
    using System.Net;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class GlobalExceptionHandler : ExceptionFilterAttribute
    {
        public static string TipoRetorno = "application/json";

        public override void OnException(ExceptionContext context)
        {
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = TipoRetorno;
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (context.Exception is DadosInvalidosException)
            {
                context.Result = new JsonResult(context.Exception.Message);
            }
            else if (context.Exception is SqlException)
            {
                context.Result = new JsonResult("Problema para conectar na base de dados SQL.");
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(context.Exception.InnerException?.Message ?? context.Exception.Message);
            }
        }
    }
}
