using System;
using System.Web.Mvc;
using Mars.Common.UnitOfWork;
using pluton.dal.Entities;
using pluton.dal.UnitOfWork;
using pluton.web.Data;

namespace pluton.web.Infrastructure.Attributes
{
    public class ActionsLoggingAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (var unitOfWork = new UnitOfWork(new PlutonContext()))
            {
                var routeDate = filterContext.RouteData;
                var currentAction = routeDate.GetRequiredString("action");
                var currentController = routeDate.GetRequiredString("controller");
                var username = filterContext.HttpContext.User.Identity.Name;
                var useragent = filterContext.HttpContext.Request.UserAgent;
                var sessionId = string.Empty;
                if (filterContext.HttpContext.Request.Cookies[".ASPXAUTH"] != null)
                    sessionId = filterContext.HttpContext.Request.Cookies[".ASPXAUTH"].Value;
                var browser = filterContext.HttpContext.Request.Browser.Type;
                var ip = filterContext.HttpContext.Request.UserHostAddress;
                var url = filterContext.HttpContext.Request.RawUrl;

                var accessLogItem = new AccessLogItem
                    {
                        DateTime = DateTime.Now,
                        Action = currentAction,
                        Controller = currentController,
                        Username = username,
                        Useragent = useragent,
                        SessionId = sessionId,
                        Browser = browser,
                        Ip = ip,
                        Url = url
                    };


                unitOfWork.Repository<AccessLogItem>().Insert(accessLogItem);
                unitOfWork.Commit();
            }
            base.OnActionExecuting(filterContext);
        }
    }

}