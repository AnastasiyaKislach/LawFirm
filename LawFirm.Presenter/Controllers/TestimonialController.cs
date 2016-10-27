using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirm.Presenter.Controllers {
	public class TestimonialController : Controller {
		public ActionResult Index() {
			return View();
		}
		// GET: Testimonial
		public ActionResult CreateTestimonial() {
			if (ModelState.IsValid) {

			}
			return PartialView("_CreateTestimonialResult");
		}
	}
}