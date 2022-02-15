using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdiestramientoParaPerros.Filters
{
    public class AuthorizeUsuariosAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

          
            if(user.Identity.IsAuthenticated == false)
            {
                ITempDataProvider provider = context.HttpContext.RequestServices.GetService(typeof(ITempDataProvider)) as ITempDataProvider;
                var TempData = provider.LoadTempData(context.HttpContext);
                string controller = context.RouteData.Values["controller"].ToString();
                string action = context.RouteData.Values["action"].ToString();

                TempData["controller"] = controller;
                TempData["action"] = action;

                provider.SaveTempData(context.HttpContext, TempData);

                context.Result = this.GetRouteRedirect("Manage", "IniciarSesion");
            }  
        }

        private RedirectToRouteResult GetRouteRedirect(String controller, String action)
        {
            RouteValueDictionary route = new RouteValueDictionary(new
            {
                controller = controller,
                action = action
            });

            RedirectToRouteResult result = new RedirectToRouteResult(route);
            return result;
        }

    }

    
}
