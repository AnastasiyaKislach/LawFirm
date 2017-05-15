using System.Collections.Generic;
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
				Testimonials = Service.GetAllApproved().Select(ToVewModel)
			};

			return View(vm);
		}

		public ActionResult Modify() {
			List<TestimonialViewModel> vm = Service.GetAll().Select(ToVewModel).ToList();

			return View("Testimonials", vm);
		}

		public void Сonfirmation(int id) {
			Testimonial testimonial = Service.GetById(id);
			testimonial.IsApproved = !testimonial.IsApproved;
			Service.Update(testimonial);
		}

		[HttpGet]
		public ActionResult Edit(int id) {
			TestimonialViewModel vm = ToVewModel(Service.GetById(id));
			return View("Edit", vm);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult Edit(TestimonialViewModel viewModel) {
			if (!ModelState.IsValid) {
				return View("Edit", viewModel);
			}

			Testimonial testimonial = ToModel(viewModel);
			testimonial.IsApproved = true;
			Service.Update(testimonial);

			List<TestimonialViewModel> vm = Service.GetAll().Select(ToVewModel).ToList();

			return View("Testimonials", vm);

		}

		public void Delete(int id) {
			Service.PartialDelete(id);
		}
		
		// GET: Testimonial
		public ActionResult CreateTestimonial(TestimonialFormViewModel model) {
			if (!ModelState.IsValid) {
				return PartialView("_TestimonialForm", model);
			}

			bool result = true;

			try {
				Testimonial testimonial = ToModel(model);

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
				Id = model.Id,
				Author = model.Author,
				Email = model.Email,
				Text = model.Text,
				CreationTime = model.CreationTime,
				IsApproved = model.IsApproved
			};
		}

		protected Testimonial ToModel(TestimonialViewModel viewModel) {
			return new Testimonial {
				Id = viewModel.Id,
				Author = viewModel.Author,
				Email = viewModel.Email,
				Text = viewModel.Text,
				CreationTime = viewModel.CreationTime,
				IsApproved = viewModel.IsApproved
			};
		}

		protected Testimonial ToModel(TestimonialFormViewModel model) {
			return new Testimonial {
				Author = model.Author,
				Email = model.Email,
				Text = model.Text,
				IsApproved = false
			};
		}
	}
}