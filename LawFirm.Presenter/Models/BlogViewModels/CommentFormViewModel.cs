using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class CommentFormViewModel {
		public string Author { get; set; }

		public string Email { get; set; }

		public string Text { get; set; }

		public DateTime Date { get; set; }

		public int IdLinkedComment { get; set; }
	}
}