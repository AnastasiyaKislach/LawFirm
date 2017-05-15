using System;
using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;

namespace LawFirm.Presenter.Controllers {
	public class AboutController : BaseController {

		protected SettingsService SettingsService { get; set; }

		public AboutController() {
			SettingsService = new SettingsService(AppConfig.ConnectionString);
		}


		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult AboutEdit() {
			AppSettings appSettings = SettingsService.GetSettings();
			ContactsViewModel viewModel = ToViewModel(appSettings);
			return View("../Home/ContactsEdit", viewModel);
		}

		private ContactsViewModel ToViewModel(AppSettings appSettings) {
			throw new NotImplementedException();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult AboutEdit(ContactsViewModel viewModel) {
			if (!ModelState.IsValid) {
				return View("../Home/ContactsEdit", viewModel);
			}
			AppSettings settings = ToModel(viewModel);

			SettingsService.SetSetting(settings);

			return RedirectToAction("Contacts", "Home");
		}

		private AppSettings ToModel(ContactsViewModel viewModel) {
			throw new NotImplementedException();
		}
	}
}