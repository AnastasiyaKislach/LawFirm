using System.Web.Mvc;
using LawFirm.Presenter.Models;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.BusinessLogic;

namespace LawFirm.Presenter.Controllers {
	public class ConsultationController : BaseController {

		protected ConsultationService Service { get; set; }

		public ConsultationController() {
			Service = new ConsultationService(AppConfig.ConnectionString);
		}

		// GET: RequestaConsultation
		public ActionResult ConsultationRequest(ConsultationPreviewViewModel model) {
			if (!ModelState.IsValid) {
				return PartialView("_ConsultationForm", model);
			}

			bool result = true;

			try {
				Consultation consultation = new Consultation() {
					Name = model.RequestViewModel.Name,
					Email = model.RequestViewModel.Email,
					Phone = model.RequestViewModel.Phone,
					MessageText = model.RequestViewModel.MessageText,
					PracticeId = model.RequestViewModel.PracticeId
				};

				Service.Add(consultation);
			}
			catch {
				result = false;
			}

			return PartialView("_ConsultationResult", result);
		}
	}
}