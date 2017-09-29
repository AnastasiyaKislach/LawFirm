using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LawFirm.Presenter.Models;
using LawFirm.Models.Entities;
using LawFirm.Presenter.Config;
using LawFirm.BusinessLogic;

namespace LawFirm.Presenter.Controllers {
	public class ConsultationController : BaseController {

		protected ConsultationService ConsultationService { get; set; }
		protected PracticeService PracticeService { get; set; }

		public ConsultationController() {
			ConsultationService = new ConsultationService(AppConfig.ConnectionString);
			PracticeService = new PracticeService(AppConfig.ConnectionString);
		}

		[Authorize(Roles = "Admin")]
		public ActionResult Modify() {
			List<ConsultationViewModel> vm = new List<ConsultationViewModel>();

			var consultationsQuery = ConsultationService.GetAll().OrderByDescending(i => i.CreationTime);

			vm = consultationsQuery.Select(ToModel).ToList();

			return View("Consultations", vm);
		}

		// GET: RequestaConsultation
		public ActionResult ConsultationRequest(ConsultationPreviewModel model) {
			if (!ModelState.IsValid) {
				return PartialView("_ConsultationForm", model);
			}

			bool result = true;

			try {
				Consultation consultation = ToModel(model.ConsultationViewModel);

				ConsultationService.Add(consultation);
			}
			catch {
				result = false;
			}

			return PartialView("_ConsultationResult", result);
		}

		public void Delete(int id) {
			ConsultationService.Delete(id);
		}

		protected Consultation ToModel(ConsultationViewModel viewModel) {
			return new Consultation {
				Id = viewModel.Id,
				Name = viewModel.Name,
				Email = viewModel.Email,
				Phone = viewModel.Phone,
				MessageText = viewModel.MessageText,
				PracticeId = viewModel.PracticeId
			};
		}

		protected ConsultationViewModel ToModel(Consultation model) {
			return new ConsultationViewModel {
				Id = model.Id,
				Name = model.Name,
				Email = model.Email,
				Phone = model.Phone,
				MessageText = model.MessageText,
				PracticeId = model.PracticeId,
				PracticeTitle = PracticeService.GetById(model.PracticeId).Title
			};
		}
	}
}