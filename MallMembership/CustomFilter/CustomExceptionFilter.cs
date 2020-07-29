using MallMembership.BusinessLayer;
using MallMembership.Entities;
using MallMembership.Utility;
using MallMemebership.DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MallMembership.CustomFilter
{/// <summary>
/// Custom Exception filter that handles the exception and also logs the exception 
/// </summary>
    public class CustomExceptionFilter : FilterAttribute , IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //filterContext.HttpContext.Request.IsAjaxRequest();
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior=JsonRequestBehavior.AllowGet,
                    Data=new
                    {
                        Message="Something went wrong"
                    }
                };
            }

            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.ExceptionHandled = true;

            ExceptionLogging logger = new ExceptionLogging()
            {
                ExceptionMessage = filterContext.Exception.Message,
                ExceptionStackTrack = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ExceptionLogTime = DateTime.Now
            };
            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            filterContext.Result = new RedirectResult(urlHelper.Action(Constants.ErrorView));
            ExceptionLog exceptionLog = new ExceptionLog();
            exceptionLog.AddException(logger);
        }
    }
}