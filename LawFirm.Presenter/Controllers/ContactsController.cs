using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;

namespace LawFirm.Presenter.Controllers {
	public class ContactsController : BaseController {

		protected SettingsService SettingsService { get; set; }

		public ContactsController() {
			SettingsService = new SettingsService(AppConfig.ConnectionString);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult ContactsEdit() {
			AppSettings appSettings = SettingsService.GetSettings();
			ContactsViewModel viewModel = ToViewModel(appSettings);
			return View("../Home/ContactsEdit", viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult ContactsEdit(ContactsViewModel viewModel) {
			if (!ModelState.IsValid) {
				return View("../Home/ContactsEdit", viewModel);
			}
			AppSettings settings = ToModel(viewModel);

			SettingsService.SetSetting(settings);

			return RedirectToAction("Contacts", "Home");
		}

		public ActionResult FeedBack(FeedBackViewModel model) {
			if (!ModelState.IsValid) {

			}
			return PartialView("../Home/_FeedBack");
		}

		private AppSettings ToModel(ContactsViewModel viewModel) {
			return new AppSettings {
				Email = viewModel.Email,
				Address = viewModel.Address,
				City = viewModel.City,
				PhoneNumber1 = viewModel.PhoneNumber1,
				PhoneNumber2 = viewModel.PhoneNumber2,
				PhoneNumber3 = viewModel.PhoneNumber3,
				WorkingHours1 = viewModel.WorkingHours1,
				WorkingHours2 = viewModel.WorkingHours2,
				WorkingHours3 = viewModel.WorkingHours3
			};
		}

		private ContactsViewModel ToViewModel(AppSettings model) {
			return new ContactsViewModel {
				Email = model.Email,
				Address = model.Address,
				City = model.City,
				PhoneNumber1 = model.PhoneNumber1,
				PhoneNumber2 = model.PhoneNumber2,
				PhoneNumber3 = model.PhoneNumber3,
				WorkingHours1 = model.WorkingHours1,
				WorkingHours2 = model.WorkingHours2,
				WorkingHours3 = model.WorkingHours3
			};
		}
	}
}