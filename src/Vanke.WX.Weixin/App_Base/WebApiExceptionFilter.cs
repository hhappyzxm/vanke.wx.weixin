using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using EZ.Framework;

namespace Vanke.WX.Weixin.App_Base
{
    public class WebApiExceptionFilter : ExceptionFilterAttribute
    {
        //读写Log4Net的句柄
        //ILog log = log4net.LogManager.GetLogger(typeof(WebApiExceptionFilter));

        public override void OnException(HttpActionExecutedContext context)
        {
            HttpError errorMessagError;

            if (context.Exception is BusinessException)
            {
                errorMessagError = new HttpError(context.Exception.Message) { { "ErrorCode", 1 } };

                //LogWebApi业务错误
                //log.Error(context.Exception.Message);
                //log.Error(context.Exception.StackTrace);
            }
            else
            {
                errorMessagError = new HttpError(context.Exception.Message) { { "ErrorCode", 2 } };

                //LogWebApi核心错误
                //log.Fatal(context.Exception.Message);
                //log.Fatal(context.Exception.StackTrace);
            }

            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError);
            //EmailRepository.SendExceptionEmail(context.Exception);
            base.OnException(context);
        }
    }
}