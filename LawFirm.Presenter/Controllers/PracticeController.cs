using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;
using LawFirm.Presenter.Models.PracticeViewModels;

namespace LawFirm.Presenter.Controllers {
	public class PracticeController : BaseController {
		protected PracticeService Service { get; set; }

		public PracticeController() {
			Service = new PracticeService(AppConfig.ConnectionString);

			//for (int i = 0; i < 6; i++) {
			//	Practice t = new Practice() {
			//		Title = "Bank And Financial",
			//		Text = "",
			//		ImagePath = String.Format("{0}/PracticeArea/{1}.jpg", AppConfig.ImagesRootPath, "family-sitting"),
			//		IsDeleted = false
			//	};
			//	Service.Add(t);
			//}
		}
		// GET: Practice
		public ActionResult Index() {
			PracticeView vm = new PracticeView {
				Practices = Service.GetAll().Select(ToVewModel)
			};

			return View(vm);
		}

		public ActionResult Details(int id) {
			Practice practice = Service.GetById(id);
			PracticeViewModel vm = new PracticeViewModel {
				Id = practice.Id,
				Title = practice.Title,
				Text = practice.Text,
				ImagePath = practice.ImagePath
			};
			return View(vm);
		}

		protected PracticeViewModel ToVewModel(Practice model) {
			return new PracticeViewModel {
				Id = model.Id,
				Title = model.Title,
				Text = model.Text,
				ImagePath = model.ImagePath
			};
		}
	}
}