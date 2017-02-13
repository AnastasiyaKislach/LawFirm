using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirm.Presenter.Models {
	public class ConsultationPreviewViewModel {
		public IEnumerable<SelectListItem> Practices { get; set; }
		public ConsultationViewModel RequestViewModel { get; set; }
	}
}