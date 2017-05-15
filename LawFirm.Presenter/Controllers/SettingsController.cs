using LawFirm.BusinessLogic;
using LawFirm.Models;
using LawFirm.Presenter.Config;

namespace LawFirm.Presenter.Controllers
{
    public class SettingsController : BaseController {

		protected SettingsService Service { get; set; }
		protected AppSettings Settings { get; private set; }

		public SettingsController() {
			Service = new SettingsService(AppConfig.ConnectionString);
		}
		protected virtual void InitSettings() {
			if (Service != null) {
				Settings = Service.GetSettings();
			}
			if (Settings == null) {
				Settings = new AppSettings();
			}
		}
		// GET: Settings
		//public ActionResult Index()
  //      {
		//	if (Service != null) {
		//		Settings = Service.GetSettings();
		//	}
		//	if (Settings == null) {
		//		Settings = new AppSettings();
		//	}
		//	return View(Settings);
  //      }
    }
}