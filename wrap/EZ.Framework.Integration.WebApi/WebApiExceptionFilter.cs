using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace EZ.Framework.Integration.WebApi
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        private const string BusinessError = "BusinessError";
        private const string SystemError = "SystemError";

        public override void OnException(HttpActionExecutedContext context)
        {
            HttpError errorMessagError;

            if (context.Exception is BusinessException)
            {
                errorMessagError = new HttpError(context.Exception.Message) { { "ErrorType", BusinessError } };

            }
            else
            {
                var errorMessage = context.Exception.InnerException?.Message ?? context.Exception.Message;
                errorMessagError = new HttpError(errorMessage) { { "ErrorType", SystemError } };
            }

            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError);

            base.OnException(context);
        }
    }
}