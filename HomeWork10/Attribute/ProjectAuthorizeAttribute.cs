using System.Web.Mvc;


namespace HomeWork10.Attribute
{
    public class ProjectAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserId"] == null)
            {
                filterContext.Result = new RedirectResult("/user/login");
                return;
            }


            base.OnActionExecuting(filterContext);
        }

    }
}