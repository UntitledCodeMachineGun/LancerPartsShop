using Microsoft.AspNetCore.Mvc.Rendering;

namespace LancerPartsShop.Service
{
	public static class Extensions
	{
		public static string CutController(this string str)
		{
			return str.Replace("Controller", "");
		}

		public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
		{
			var routeData = htmlHelper.ViewContext.RouteData;

			var routeAction = routeData.Values["action"].ToString();
			var routeController = routeData.Values["controller"].ToString();

			var returnActive = (controller == routeController && (action == routeAction || routeAction == "Details"));

			return returnActive ? "active" : "";
		}
	}
}
