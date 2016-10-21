using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models;

namespace LawFirm.Presenter.Controllers
{
    public abstract class BaseController : Controller
    {
		protected AppSettings AppSettings { get; private set; }

	    protected BaseController() {
			SettingsService service = new SettingsService(Config.ConnectionString);
		    AppSettings = service.GetSettings();
	    }
    }
}