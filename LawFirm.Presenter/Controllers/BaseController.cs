using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models;
using LawFirm.Presenter.Config;

namespace LawFirm.Presenter.Controllers
{
    public abstract class BaseController : Controller
    {
		protected AppSettings AppSettings { get; private set; }
		
	    protected BaseController() {
			SettingsService service = new SettingsService(AppConfig.ConnectionString);
		    AppSettings = service.GetSettings();
			ViewBag.AppSettings = AppSettings;
		}

		//protected abstract TViewModel ToViewModel(TModel model);
		//protected abstract TModel ToModel(TViewModel viewModel);
	}
}