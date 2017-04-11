using System;
using System.Net;
using System.Security.Principal;
using System.Web.Mvc;

namespace LawFirm.Presenter.Attributes {
	public class AuthorizeRedirect : AuthorizeAttribute
	{
		private readonly string defaultRedirectUrl = "/Account/Login";

		public string RedirectUrl { get; set; }

		public bool IsJson { get; set; }

		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			IIdentity identity = filterContext.HttpContext?.User?.Identity;

			if (identity == null || !identity.IsAuthenticated)
			{
				string redirectUrl = String.IsNullOrEmpty(RedirectUrl) ? defaultRedirectUrl : RedirectUrl;

				if (IsJson)
				{
					filterContext.Result = new JsonResult
					{
						Data = new
						{
							statusCode = HttpStatusCode.Redirect,
							redirectUrl
						}
					};
				}
				else
				{
					filterContext.Result = new RedirectResult(redirectUrl);
				}
			}
			else
			{
				base.OnAuthorization(filterContext);
			}
		}
	}
}