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