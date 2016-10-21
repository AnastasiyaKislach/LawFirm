using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawFirm.Presenter.Models;

namespace LawFirm.Presenter.Controllers {
	public class ConsultationController : Controller {
		// GET: RequestaConsultation
		public ActionResult ConsultationRequest(ConsultationPreviewViewModel model) {
			if (ModelState.IsValid) {

			}
			return PartialView("_ConsultationResult");
		}
	}
}