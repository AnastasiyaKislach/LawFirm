using System;
using System.Linq;
using System.Web.Mvc;
using LawFirm.BusinessLogic;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.Presenter.Models.TestimonialViewModels;

namespace LawFirm.Presenter.Controllers {
	public class TestimonialController : BaseController {
		protected TestimonialService Service { get; set; }

		public TestimonialController() {
			Service = new TestimonialService(AppConfig.ConnectionString);

			//for (int i = 0; i < 6; i++) {
			//	Testimonial t = new Testimonial() {
			//		Email = "qwe@qwe",
			//		Text = "Maecenas etos sit amet, consectetur adipis cing elit. Terminal volutpat rutrum metro amet sollicitudin interdum." +
			//			"Ante tellus gravida mollis tellus neque vitae elit. Mauris adipiscing mauris...",
			//		Author = "Инесса Карпинская",
			//		IsDeleted = false
			//	};
			//	Service.Add(t);
			//}

		}

		public ActionResult Index() {
			TestimonialView vm = new TestimonialView {
				Testimonials = Service.GetAll().Select(ToVewModel)
			};

			return View(vm);
		}

		// GET: Testimonial
		public ActionResult CreateTestimonial(TestimonialFormViewModel model) {
			if (!ModelState.IsValid) {
				return PartialView("_TestimonialForm", model);
			}

			bool result = true;

			try {
				Testimonial testimonial = ToModel(model);
				testimonial.IsApprove = false;

				Service.Add(testimonial);
			}
			catch {
				result = false;
			}

			return PartialView("_TestimonialFormResult", result);
		}

		[HttpGet]
		public ActionResult TestimonialForm() {
			return PartialView("_TestimonialForm", new TestimonialFormViewModel());
		}

		protected TestimonialViewModel ToVewModel(Testimonial model) {
			return new TestimonialViewModel {
				Author = model.Author,
				Email = model.Email,
				Text = model.Text,
				CreationTime = model.CreationTime
			};
		}

		protected Testimonial ToModel(TestimonialFormViewModel model) {
			return new Testimonial {
				Author = model.Author,
				Email = model.Email,
				Text = model.Text
			};
		}
	}
}