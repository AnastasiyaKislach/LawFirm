using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawFirm.Presenter.Models.BlogViewModels {
	public class CommentFormViewModel {
		public int IdUser { get; set; }

		public string Email { get; set; }

		public string Text { get; set; }

		public DateTime CreationTime { get; set; }

		public int IdLinkedComment { get; set; }

		public int IdArticle { get; set; }
	}
}