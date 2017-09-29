using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models.PracticeViewModels;

namespace LawFirm.Presenter.Controllers {
	public class PracticeController : BaseController {
		protected PracticeService Service { get; set; }

		public PracticeController() {
			Service = new PracticeService(AppConfig.ConnectionString);

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
			PracticeViewModel vm = ToVewModel(practice);
			return View(vm);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult Create() {
			return View("Create");
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Create(PracticeViewModel viewModel, HttpPostedFileBase upload) {

			if (upload == null) {
				ModelState.AddModelError("Url", "Требуется поле Изображение");
				return View(viewModel);
			}

			if (!ModelState.IsValid) {
				return View("Create", viewModel);
			}

			Practice practice = ToModel(viewModel);

			// получаем имя файла
			string fileName = System.IO.Path.GetFileName(upload.FileName);
			// сохраняем файл в папку Files в проекте
			upload.SaveAs(Server.MapPath(AppConfig.PracticeImagesPath + fileName));
			practice.ImagePath = upload.FileName;

			Practice newPractice = Service.Add(practice);

			PracticeViewModel vm = ToVewModel(newPractice);

			return View("Details", vm);
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(int id) {
			PracticeViewModel vm = ToVewModel(Service.GetById(id));
			return View("Edit", vm);
		}

		[HttpPost]
		public ActionResult Edit(PracticeViewModel viewModel, HttpPostedFileBase upload) {
			if (!ModelState.IsValid) {
				return View("Edit", viewModel);
			}

			Practice practice = ToModel(viewModel);

			if (upload != null) {
				// получаем имя файла
				string fileName = System.IO.Path.GetFileName(upload.FileName);
				// сохраняем файл в папку Files в проекте
				upload.SaveAs(Server.MapPath(AppConfig.PracticeImagesPath + fileName));
				practice.ImagePath = upload.FileName;
			}

			Service.Edit(practice);

			PracticeViewModel vm = ToVewModel(Service.GetById(practice.Id));

			return View("Details", vm);

		}

		[Authorize(Roles = "Admin")]
		public void Delete(int id) {
			Service.Delete(id);
		}

		protected PracticeViewModel ToVewModel(Practice model) {
			return new PracticeViewModel {
				Id = model.Id,
				Title = model.Title,
				Text = model.Text,
				ImagePath = AppConfig.PracticeImagesPath + model.ImagePath
			};
		}

		protected Practice ToModel(PracticeViewModel model) {
			return new Practice {
				Id = model.Id,
				Title = model.Title,
				ImagePath = model.ImagePath?.Replace(AppConfig.PracticeImagesPath, "") ?? "",
				Text = model.Text
			};
		}
	}
}