using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LawFirm.Presenter.Controllers {
	public class QuestionController : BaseController {
		protected QuestionService Service { get; set; }

		public QuestionController() {
			Service = new QuestionService(AppConfig.ConnectionString);
		}

		// GET: Question
		public ActionResult Index() {
			IList<QuestionViewModel> vm = Service.GetAll().Select(ToVewModel).ToList();
			return View(vm);
		}

		public ActionResult Details(int id) {
			Question question = Service.GetById(id);
			QuestionViewModel vm = new QuestionViewModel {
				Id = question.Id,
				QuestionText = question.QuestionText,
				Answer = question.Answer
			};
			return View(vm);
		}

		public ActionResult Modify() {
			List<QuestionViewModel> vm = Service.GetAll().Select(ToVewModel).ToList();

			return View("Questions", vm);
		}

		[HttpGet]
		public ActionResult Create() {
			return View("Create");
		}

		[HttpPost]
		public ActionResult Create(QuestionViewModel viewModel) {
			if (!ModelState.IsValid) {
				return View("Create", viewModel);
			}

			Question question = ToModel(viewModel);
			Service.Add(question);

			List<QuestionViewModel> vm = Service.GetAll().Select(ToVewModel).ToList();
			return View("Questions", vm);
		}

		[HttpGet]
		public ActionResult Edit(int id) {
			QuestionViewModel vm = ToVewModel(Service.GetById(id));
			return View("Edit", vm);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(QuestionViewModel viewModel) {
			if (!ModelState.IsValid) {
				return View("Edit", viewModel);
			}

			Question question = ToModel(viewModel);
			Service.Update(question);

			List<QuestionViewModel> vm = Service.GetAll().Select(ToVewModel).ToList();

			return View("Questions", vm);

		}
		
		[Authorize]
		public void Delete(int id) {
			Service.PartialDelete(id);
		}

		protected QuestionViewModel ToVewModel(Question model) {
			return new QuestionViewModel {
				Id = model.Id,
				QuestionText = model.QuestionText,
				Answer = model.Answer
			};
		}

		protected Question ToModel(QuestionViewModel model) {
			return new Question {
				Id = model.Id,
				QuestionText = model.QuestionText,
				Answer = model.Answer
			};
		}
	}
}