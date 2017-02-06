using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models {
	public class QuestionViewModel {
		public int Id { get; set; }

		public string QuestionText { get; set; }

		public string Answer { get; set; }
	}
}