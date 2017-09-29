using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LawFirm.Presenter.Models {
	public class ConsultationPreviewModel {
		public IEnumerable<SelectListItem> Practices { get; set; }
		public ConsultationViewModel ConsultationViewModel { get; set; }
	}
}