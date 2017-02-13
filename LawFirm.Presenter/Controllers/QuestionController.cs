using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirm.Presenter.Controllers {
	public class QuestionController : BaseController {
		protected QuestionService Service { get; set; }

		public QuestionController() {
			Service = new QuestionService(AppConfig.ConnectionString);

			//for (int i = 0; i < 6; i++) {
			//	Question question = new Question() {
			//		QuestionText = String.Format("Вопрос {0}", i),
			//		Answer = "Lorem ipsum dolor sit amet, consectetur adipisicing elit," +
			//				 "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad" +
			//				 "minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
			//	};
			//	Service.Add(question);
			//	}
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

		protected QuestionViewModel ToVewModel(Question model) {
			return new QuestionViewModel {
				Id = model.Id,
				QuestionText = model.QuestionText,
				Answer = model.Answer
			};
		}
	}
}