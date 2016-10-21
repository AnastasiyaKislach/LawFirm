using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirm.Presenter.Models {
	public class ConsultationPreviewViewModel {
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ButtonText { get; set; }
		public string PhDescription { get; set; }
		public string PhName { get; set; }
		public string PhEmail { get; set; }
		public string PhPhone { get; set; }//PhonePlaceholder
		public string PhAreasOfPractice { get; set; }
		public IEnumerable<SelectListItem> PracticeAreas { get; set; }
		public ConsultationViewModel RequestViewModel { get; set; }

	}
}