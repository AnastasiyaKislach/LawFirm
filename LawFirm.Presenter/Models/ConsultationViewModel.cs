using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models {
	public class ConsultationViewModel {
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int PracticeAreaId { get; set; }
		public string Description { get; set; }
	}
}